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
    private SpriteRenderer _spriteCompo;
    [SerializeField] private PlayerAnimation _playerAnimCompo;

    public int brightStep;

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

        _spriteCompo = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _colliders = new Collider2D[20];

        existsNowBrightObj = GameObject.Find("BrightObjManager").GetComponentsInChildren<IBrightDetection>();
    }

    private void Update()
    {
        PlantRenderer();
    }

    private void BrightnessControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 0.4f);
            _light.intensity += 0.1f;
            brightStep = (int)(_light.intensity * 10);
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 0.4f);
            _light.intensity -= 0.1f;
            brightStep = (int)(_light.intensity * 10);
            print(brightStep);
        }
    }
   
    //public Collider2D GetBright()
    //{
    //    _cut = Physics2D.OverlapCircleNonAlloc(transform.position, size, _colliders, foothold);
    //    return  _cut > 0 ?_colliders[0] : null;
    //}

    private void BrightnessRange()
    {
        //_colliders = Physics2D.OverlapCircleAll(transform.position, size, foothold);

        //for(int i= 0; i<_colliders.Length; i++)
        //{
        //    var test = _colliders[i]?.GetComponent<IBrightDetection>();
        //    _colliders[i]?.GetComponent<IBrightDetection>().BrightnessDetection(true, brightStep);
        //    test.isBrightOn = true;
        //}

        //if (GetBright())
        //{
        //    for (int i = 0; i < _colliders.Length; i++)
        //    {
        //        IBrightDetection keepBright = _colliders[i]?.GetComponent<IBrightDetection>();
        //        if (keepBright != null)
        //        {
        //            keepBright.BrightnessDetection(true, brightStep);
        //        }
        //    }
        //}
        //else
        //{
        //    if (existsNowBrightObj.Length > 0)
        //    {
        //        for (int j = 0; j < existsNowBrightObj.Length; j++)
        //        {
        //            existsNowBrightObj[j].BrightnessDetection(false, brightStep);
        //        }
        //    }
        //}
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }

    private void PlantRenderer()
    {
        if (luminescentPlants._isHold)
        {
            _spriteCompo.color = new Color(1, 1, 1, 0);
            _playerAnimCompo.isFlower = true;
        }
        else
        {
            _spriteCompo.color = new Color(1, 1, 1, 1);
            _playerAnimCompo.isFlower = false;
        }
    }
}
