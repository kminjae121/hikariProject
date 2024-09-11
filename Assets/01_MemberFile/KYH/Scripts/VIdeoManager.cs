using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VIdeoManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer introVideo;

    [SerializeField]
    private Intro intro;

    [SerializeField]
    private GameObject videoRawImage;
    [SerializeField]
    private GameObject[] testActiveFalse;

    private void Update()
    {
        if(introVideo.time > 31f)
        {
            intro.BlinkTween();
            introVideo.Stop();
            videoRawImage.SetActive(false);

            for(int i =0; i<testActiveFalse.Length; i++)
            {
                testActiveFalse[i].SetActive(false);
            }
        }
    }
}
