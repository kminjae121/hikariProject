using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.Video;

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

    private void Start()
    {
        noise = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (GameManager.Instance.isClearSea)
        {
            

            if(GameManager.Instance.isCapture)
            {

            }
        }
        else
        {
            videoManager.StartVideo();
        }
    }

    public void PlayerFallingShakeEffect()
    {
        StartCoroutine(FallingShakeEffectRoutine());
    }

    public void OnButton()
    {
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
        yield return new WaitForSeconds(2f);
        playerSprite.SetActive(true);
        explotionParticle.Play();
        playerBoom.Play();
        noise.m_AmplitudeGain = 2f;
        noise.m_FrequencyGain = 4f;
        vc.Priority = 0;
        yield return new WaitForSeconds(0.5f);
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
        //if(player.length < 31f)

        //double videoCurrentTime = player.time;

    }
}
