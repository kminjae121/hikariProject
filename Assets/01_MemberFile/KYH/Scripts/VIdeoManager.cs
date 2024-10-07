using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using DG.Tweening;
using System;

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

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private TextMeshProUGUI youCanSkipText;

    private float skipGage;
    [SerializeField]
    private GameObject skipGageBar;

    [SerializeField]
    private GameObject speedVideo;

    private bool sorry;
    private bool sorry2;
    private bool sorry3;
    private bool sorry4;
    private bool sorry5;
    private bool sorry6;
    private bool isSpeedy = false;

    private void Start()
    {
        StartCoroutine(WaitRoutine());
    }

    private IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(1f);
        youCanSkipText.DOFade(1, 1);
        yield return new WaitForSeconds(3f);
        youCanSkipText.DOFade(0, 1);
    }

    public void StartHouseVideo()
    {
        introCanvas.SetActive(true);
        introVideo.Play();
    }

    public void StartComputerVideo()
    {
        introVideo.clip = computerClip;
        introVideo.Play();
        StartCoroutine(FrameBugFix());
    }

    private void Update()
    {
        if(isSpeedy)
        {
            introVideo.playbackSpeed = 5;
            speedVideo.SetActive(true);
        }
        else
        {
            introVideo.playbackSpeed = 1;
            speedVideo.SetActive(false);
        }


        if (!(introVideo.clip == computerClip))
        {
            skipGageBar.GetComponent<RectTransform>().localScale = new Vector3(skipGage,skipGageBar.transform.localScale.y,0);
            if (Input.GetKey(KeyCode.Space))
            {
                if (skipGage > 8)
                {
                    FirstIntroEnd();
                    skipGageBar.SetActive(false);
                }
                else
                {
                    skipGage += Time.deltaTime *2;
                    skipGageBar.GetComponent<Image>().DOFade(1,skipGage);
                }
            }
            else
            {
                if(skipGage > 0)
                {
                    skipGage -= Time.deltaTime * 3;
                    skipGageBar.GetComponent<Image>().DOFade(0, skipGage);
                }
            }

            if (introVideo.time > 0f && !sorry)
            {
                IntroText();
            }
            if (introVideo.time > 6f && !sorry2)
            {
                FirstIntroText();
            }
            if (introVideo.time > 11f && !sorry3)
            {
                SecondIntroText();
            }
            if (introVideo.time > 18f && !sorry4)
            {
                ThirdIntroText();
            }
            if (introVideo.time > 25f)
            {
                FirstIntroEnd();
            }
        }
        else
        {
            skipGageBar.SetActive(false);
            if (introVideo.time > 1f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isSpeedy = !isSpeedy;
                }
            }
            if (introVideo.time > 31f)
            {
                isSpeedy = false;
                speedVideo.SetActive(false);
                intro.BlinkTween();
                introVideo.Stop();
                videoRawImage.SetActive(false);
                windowVolume.SetActive(true);

                for (int i = 0; i < testActiveFalse.Length; i++)
                {
                    testActiveFalse[i].SetActive(false);
                }
            }
        }
    }

    private void FirstIntroEnd()
    {
        introVideo.Stop();
        blackPanel.SetActive(true);
        StartCoroutine(BlackPanelWateRoutine());
        text.gameObject.SetActive(false);
    }

    public void IntroText()
    {
        if (!sorry)
        {
            sorry = true;
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    public void FirstIntroText()
    {
        if(!sorry2)
        {
            sorry2 = true;
            text.text = "이제 슬슬 시작해야겠지?";
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    public void SecondIntroText()
    {
        if (!sorry3)
        {
            sorry3 = true;
            text.text = "이번에도 늦으면 교수님 얼굴 어떻게 보고살아";
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    public void ThirdIntroText()
    {
        if (!sorry4)
        {
            sorry4 = true;
            text.text = "그냥 빨리 끝내버리자";
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    private IEnumerator BlackPanelWateRoutine()
    {
        yield return new WaitForSeconds(2f);
        StartComputerVideo();
    }

    private IEnumerator FrameBugFix()
    {
        yield return new WaitForSeconds(0.3f);
        blackPanel.SetActive(false);
    }
}
