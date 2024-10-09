using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class BrightPlants : MonoBehaviour
{
    [Header("Luminescent Plants Input")]
    [SerializeField]
    private LuminescentPlants luminescentPlants;
    [SerializeField]
    public Light2D light;
    [SerializeField] private GameObject levelTxt;

    [Header("Player Input")]
    [SerializeField] private PlayerAnimation _playerAnimCompo;

    [SerializeField] private Collider2D[] _colliders;
    [SerializeField] private List<GameObject> _inLightList = new();
    public ContactFilter2D filter;
    public bool _isReach;
    public bool canPlant;
    public int brightStep;


    private SpriteRenderer _spriteCompo;

    private float size = 3f;


    private void Awake()
    {
        light.intensity = 0;

        luminescentPlants.OnPlants += BrightnessRange;
        luminescentPlants.OnPlants += BrightnessControl;

        _spriteCompo = GetComponent<SpriteRenderer>();

        _colliders = new Collider2D[10];
    }

    private void Start()
    {
        _colliders = new Collider2D[20];
    }

    private void Update()
    {
        PlantRenderer();
    }

    private void BrightnessControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            light.intensity = Mathf.Clamp(light.intensity, 0f, 0.4f);

            if (light.intensity >= 0.4f)
                return;

            light.intensity += 0.1f;
            brightStep = (int)(light.intensity * 10);
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            light.intensity = Mathf.Clamp(light.intensity, 0f, 0.4f);

            if (light.intensity <= 0)
                return;

            light.intensity -= 0.1f;
            brightStep = (int)(light.intensity * 10);
            print(brightStep);
        }

        levelTxt.GetComponent<TextMeshPro>().text = brightStep.ToString();
    }


    private void BrightnessRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, size, filter, _colliders);

        for (int i = 0; i < count; i++)
        {
            var detector = _colliders[i].GetComponent<IBrightDetection>();
            if(detector != null && !_inLightList.Contains(_colliders[i].gameObject))
                _inLightList.Add(_colliders[i].gameObject);
        }

        CheckInRadius();
    }

    private void CheckInRadius()
    {
        for (int i = 0; i < _inLightList.Count; i++)
        {
            var obj = _inLightList[i];
            var item = obj.GetComponent<IBrightDetection>();
            Debug.Log(item);
            if (Vector2.Distance(item.GameObject.transform.position, transform.position) < size)
            {
                item.BrightnessDetection(true, brightStep);
            }
            else
            {
                item.BrightnessDetection(false, brightStep);
                _inLightList.RemoveAt(i);
                i--;
            }
        }
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
