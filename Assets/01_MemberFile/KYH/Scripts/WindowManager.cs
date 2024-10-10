using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.Video;
using System;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera vc;
    CinemachineBasicMultiChannelPerlin noise;

    [SerializeField]
    private VIdeoManager videoManager;

    public GameObject toolBox;
    [SerializeField]
    private ParticleSystem explotionParticle;

    [SerializeField]
    private PlayableDirector playerBoom;

    [SerializeField]
    private GameObject playerSprite;

    [SerializeField]
    private FolderManager folderManager;

    public List<GameObject> gameObjects = new List<GameObject>();

    public GameObject questCanvas;

    [SerializeField]
    private StageApp stageApp;

    [SerializeField]
    private CinemachineVirtualCamera tutorialCamera;
    private bool isRepeat;
    private bool isStartTutorial;

    [SerializeField]
    private GameObject tutorialBox;

    [SerializeField]
    private GameObject esc;
    [SerializeField]
    private GameObject escPanel;

    private void Start()
    {
        noise = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if(GameManager.Instance.isFinishTutorial)
        {
            stageApp.FinishTutorial();

            if (GameManager.Instance.isClearSea)
            {
                stageApp.ClearChrome();
                SoundManager.Instance.ChangeMainStageVolume("windowSceneBGM", true, ISOund.BGM);
                if (GameManager.Instance.isCapture)
                {

                }
            }
        }
        else
        {
            videoManager.StartHouseVideo();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(isStartTutorial && Input.GetKeyDown(KeyCode.Escape))
        {
            tutorialBox.SetActive(true);
            isRepeat = true;
            escPanel.SetActive(true);
        }
    }

    public void PlayerFallingShakeEffect()
    {
        StartCoroutine(FallingShakeEffectRoutine());
    }

    public void OnButton()
    {
        GameManager.Instance.isFinishIntro = true;
        folderManager.isDisableOnButton = true;
        toolBox.SetActive(false);
        vc.Priority = 10;
        
        StartCoroutine(CutSceneRoutine());
    }

    private IEnumerator FallingShakeEffectRoutine()
    {
        noise.m_AmplitudeGain = 3f;
        noise.m_FrequencyGain = 4f;
        yield return new WaitForSeconds(1f);
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }

    private IEnumerator CutSceneRoutine()
    {
        yield return new WaitForSeconds(1f);
        noise.m_AmplitudeGain = 0.6f;
        noise.m_FrequencyGain = 0.1f;
        yield return new WaitForSeconds(2f);
        noise.m_AmplitudeGain = 3f;
        noise.m_FrequencyGain = 4f;
        yield return new WaitForSeconds(1f);
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.ChangeMainStageVolume("Explosion", true, ISOund.VFX);
        yield return new WaitForSeconds(1f);
        playerSprite.SetActive(true);
        explotionParticle.Play();
        playerBoom.Play();
        SetActiveTrueApp();
        noise.m_AmplitudeGain = 2f;
        noise.m_FrequencyGain = 4f;
        vc.Priority = 0;
        yield return new WaitForSeconds(0.5f);
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
        questCanvas.SetActive(true);
        StartTutorial();
        isStartTutorial = true;
        //if(player.length < 31f)

        //double videoCurrentTime = player.time;

    }

    private void StartTutorial()
    {
        StartCoroutine(StartTutorialRoutine());
    }

    private IEnumerator StartTutorialRoutine()
    {
        yield return new WaitForSeconds(3f);
        SoundManager.Instance.ChangeMainStageVolume("windowSceneBGM", true, ISOund.BGM);
        TutorialCamera();
        PlayerChatBoxManager.Instance.Show("자 이제 과제를\n시작해볼까?", 3f, false)
            .Show("ESC를 눌러서 컴퓨터가 잘 작동되는지 확인해보자", 6f, false)
            .End();
        yield return new WaitForSeconds(3f);
        CancelTutorialCamera();
        StartCoroutine(RepeatChat());
    }

    private IEnumerator RepeatChat()
    {
        if(!isRepeat)
        {
            esc.SetActive(true);
            PlayerChatBoxManager.Instance.Show("ESC를 눌러서 컴퓨터가 잘 작동되는지 확인해보자", 6f, false)
            .Show("안 킨지 오래됐는데..ESC를 눌러서 확인해볼까?", 3f, false)
            .End();
            yield return new WaitForSeconds(10f);
            PlayerChatBoxManager.Instance.Show("ESC 눌러서 확인한번 해보자", 3f, false)
            .Show("아..배고프다 과제 이따가 할까", 3f, false)
            .End();
            yield return new WaitForSeconds(8f);
            if (!isRepeat)
            {
                StartCoroutine(RepeatChat());
            }
        }
    }

    private void TutorialCamera()
    {
        tutorialCamera.Priority = 30;
    }

    private void CancelTutorialCamera()
    {
        tutorialCamera.Priority = -1;
    }

    private void SetActiveTrueApp()
    {
        for(int i=0; i<gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }
}
