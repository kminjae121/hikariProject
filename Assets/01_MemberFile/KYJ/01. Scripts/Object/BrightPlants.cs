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
    private BrightFoothold brightFoothold;
    [SerializeField]
    private Light2D _light;
    [SerializeField]

    public float brightStep;

    public Vector2 pos;
    private float size = 3f;
    public LayerMask foothold;

    public bool _isReach;
    public bool canPlant;

    private void Awake()
    {
        _light.intensity = 0;

        luminescentPlants.OnPlants += BrightnessRange;
        luminescentPlants.OnPlants += BrightnessControl;
    }

    private void BrightnessControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _light.intensity += 2;
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 8);
            brightStep = _light.intensity / 2;
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _light.intensity -= 2;
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 8);
            brightStep = _light.intensity / 2;
            print(brightStep);
        }
    }

    private void BrightnessRange()
    {
        Collider2D[] collision = Physics2D.OverlapCircleAll(transform.position, size, foothold);

        for (int i = 0; i < collision.Length; i++)
        {
            if (collision != null)
            {
                collision[i].GetComponent<BrightFoothold>().BrightnessDetection(true, brightStep);
            }
            if (!collision[i])
            {
                brightFoothold.BrightnessDetection(false, brightStep);
            }
        }
    }


    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
