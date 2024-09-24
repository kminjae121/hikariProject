using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingBar : MonoBehaviour
{
    [SerializeField] private Slider _walkingDollSlider;

    private void Awake()
    {
        _walkingDollSlider.maxValue = 6;
    }

    private void Update()
    {
        _walkingDollSlider.value = ObjectGather.maxMoveDoolDistance;
    }
}
