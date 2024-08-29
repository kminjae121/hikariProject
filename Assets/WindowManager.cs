using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera vc;
    CinemachineBasicMultiChannelPerlin noise;

    public void OnButton()
    {
        vc.Priority = 10;
        noise = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(CutSceneRoutine());
    }

    private IEnumerator CutSceneRoutine()
    {
        yield return new WaitForSeconds(1f);
        noise.m_AmplitudeGain = 0.6f;
        noise.m_FrequencyGain = 0.1f;
        yield return new WaitForSeconds(3f);
        noise.m_AmplitudeGain = 3f;
        noise.m_FrequencyGain = 4f;
        yield return new WaitForSeconds(1f);
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;

    }
}
