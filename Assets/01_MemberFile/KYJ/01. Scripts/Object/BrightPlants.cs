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
    private Light2D _light;
    [SerializeField]

    public float brightStep;

    private int _cut;

    [SerializeField] private Collider2D[] _colliders;

    public Vector2 pos;
    private float size = 3f;
    public LayerMask foothold;

    public bool _isReach;
    public bool canPlant;


    [SerializeField]
    private IBrightDetection[] existsNowBrightObj;

    private void Awake()
    {
        _light.intensity = 0;

        luminescentPlants.OnPlants += BrightnessRange;
        luminescentPlants.OnPlants += BrightnessControl;

    }

    private void Start()
    {
        _colliders = new Collider2D[20];

        existsNowBrightObj = GameObject.Find("BrightObjManager").GetComponentsInChildren<IBrightDetection>();
    }

    private void BrightnessControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _light.intensity += 0.1f;
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 0.4f);
            brightStep = _light.intensity * 10;
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _light.intensity -= 0.1f;
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 0.4f);
            brightStep = _light.intensity * 10;
            print(brightStep);
        }
    }
   

    public Collider2D GetBright()
    {
        _cut = Physics2D.OverlapCircleNonAlloc(transform.position, size, _colliders, foothold);
        return  _cut > 0 ?_colliders[0] : null;
    }

    private void BrightnessRange()
    {
        
        if (GetBright())
        {
            for (int i = 0; i < _colliders.Length; i++)
            {

                IBrightDetection keepBright = _colliders[i]?.GetComponent<IBrightDetection>();
                if (keepBright != null)
                {
                    print($"{_colliders[i].name}들어옴");
                    keepBright.BrightnessDetection(true, brightStep);
                }
            }
        }
        else
        {
            print("안 닿음");
            if (existsNowBrightObj.Length > 0)
            {
                for (int j = 0; j < existsNowBrightObj.Length; j++)
                {
                    existsNowBrightObj[j].BrightnessDetection(false, brightStep);
                }
            }
        }
    }


    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
