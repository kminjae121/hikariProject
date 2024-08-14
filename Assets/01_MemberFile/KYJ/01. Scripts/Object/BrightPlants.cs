using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.Universal ;

public class BrightPlants : MonoBehaviour
{
    [SerializeField]
    private LuminescentPlants plants;
    [SerializeField]
    private Light2D light2D;
    [SerializeField]
    private BrightFoothold brightFoothold;

    public int brightStep = Math.Clamp(0 , 0, 4);

    public Vector2 pos;
    private float size = 3f;
    public LayerMask foothold;


    public bool isOn;

    private void Awake()
    {
        light2D.intensity = 0;

        plants.OnPlants += Overlap;
        plants.OnPlants += BrightnessControl;
    }

    private void BrightnessControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            light2D.intensity += 2.5f;
            brightStep += 1;
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            light2D.intensity -= 2.5f;
            brightStep -= 1;
            print(brightStep);
        }
    }

    private void Overlap()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, size, foothold);
        if (collision)
        {
            isOn = true;
            brightFoothold.BrightStep();
        }
        if(!collision)
        {
            isOn = false;
            brightFoothold.BrightStep();
        }
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
