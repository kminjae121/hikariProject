using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class BloomLerp : MonoBehaviour
{
    private bool isBloomActive = false;
    Volume Volume;
    private Bloom bloom;
    private void Awake()
    {
        Volume = GetComponent<Volume>();

        if (Volume.profile.TryGet(out bloom))
        {
           
            bloom.intensity.value = 1f; //
            bloom.threshold.value = 0.2f; // 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBloomActive == true)
        {
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 1000f, 0.01f * Time.deltaTime);

       
        }
    }
    public void Moolom()
    {
        isBloomActive = true;
    }

}
