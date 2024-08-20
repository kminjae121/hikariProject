using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.Universal ;

public class BrightPlants : MonoBehaviour
{
    [SerializeField]
    private LuminescentPlants luminescentPlants;
    [SerializeField]
    private Light2D light;
    [SerializeField]
    private BrightFoothold brightFoothold;

    public float brightStep ;

    public Vector2 pos;
    private float size = 3f;
    public LayerMask foothold;

    public bool isReach;

    private void Awake()
    {
        light.intensity = 0;

        luminescentPlants.OnPlants += BrightnessRange;
        luminescentPlants.OnPlants += BrightnessControl;
    }

    private void BrightnessControl()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            light.intensity += 2;
            light.intensity = Mathf.Clamp(light.intensity, 0, 8);
            brightStep = light.intensity / 2;
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            light.intensity -= 2;
            light.intensity = Mathf.Clamp(light.intensity, 0, 8);
            brightStep = light.intensity / 2;
            print(brightStep);
        }
    }

    private void BrightnessRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, size, foothold);
        if (collision)
        {
            isReach = false;
            brightFoothold.BrightnessDetection();
            print("dd");
        }
        else if(!collision)
        {
            isReach = true;
            brightFoothold.BrightnessDetection();
            print("dddddd");
        }
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
