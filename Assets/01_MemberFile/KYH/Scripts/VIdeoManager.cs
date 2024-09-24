using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VIdeoManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer introVideo;

    [SerializeField]
    private GameObject introCanvas;

    [SerializeField]
    private GameObject windowVolume;

    [SerializeField]
    private Intro intro;

    [SerializeField]
    private GameObject videoRawImage;
    [SerializeField]
    private GameObject[] testActiveFalse;


    [SerializeField]
    private VideoClip computerClip;
    [SerializeField]
    private GameObject blackPanel;


    public void StartHouseVideo()
    {
        introCanvas.SetActive(true);
        introVideo.Play();
    }

    public void StartComputerVideo()
    {
        introVideo.clip = computerClip;
        introVideo.Play();
        blackPanel.SetActive(false);
    }

    private void Update()
    {
        if(introVideo.clip == computerClip)
        {
            if(introVideo.time > 31f)
            {
                intro.BlinkTween();
                introVideo.Stop();
                videoRawImage.SetActive(false);
                windowVolume.SetActive(true);

                for (int i =0; i<testActiveFalse.Length; i++)
                {
                    testActiveFalse[i].SetActive(false);
                }
            }
        }
        else
        {
            if (introVideo.time > 25f)
            {
                blackPanel.SetActive(true);
                StartCoroutine(BlackPanelWateRoutine());
            }
        }
    }

    private IEnumerator BlackPanelWateRoutine()
    {
        yield return new WaitForSeconds(2f);
        StartComputerVideo();
    }
}
