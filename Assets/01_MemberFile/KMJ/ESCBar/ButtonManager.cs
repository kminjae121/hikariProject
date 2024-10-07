using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoSingleton<ButtonManager>
{
    private static int _mainvalue;
    private static int _effectvalue;

    private int _randomInt;
    private static float _currentTime;

    [SerializeField] public GameObject _esc;
    [SerializeField] public TextMeshProUGUI _currentText;
    [SerializeField] public Button _brightButton;
    [Header("¹æÈ­º®")]
    [SerializeField] public TextMeshProUGUI _fireWallTrueText;
    [SerializeField] public Texture _basicFireWallSprtie;
    [SerializeField] public Texture _falseFireWallSprtie;
    [SerializeField] public RawImage _fireWallManager;
    public static bool IsFireWallTrue = false;
    [Header("Wifi")]
    [SerializeField] private TextMeshProUGUI _wifiCollectText;
    [SerializeField] private SpriteRenderer _wifiRenderer;
    [SerializeField] private Sprite _falsewifiRenderer;

    [field: SerializeField] public bool isEscFalse;
    [field: SerializeField] public static bool IsWifiTrue { get; set; } = false;
    [SerializeField] public Animator _wifiAniamtion;
    [Header("Sound")]
    [SerializeField] public TextMeshProUGUI _MainsoundText;
    [SerializeField] public Slider _MainmusicSlider;

    [SerializeField] public TextMeshProUGUI _EffectsoundText;
    [SerializeField] public Slider _EffectmusicSlider;

    [Header("ButtonList")]
    public List<GameObject> ChangeButton = new List<GameObject>();
    public static int SceneNumber;

    private void Awake()
    {
        isEscFalse = false;

        _esc.SetActive(false);

        _randomInt = Random.Range(1, 4);
    }

    private void Start()
    {
        _MainmusicSlider.value = _mainvalue;
        _EffectmusicSlider.value = _effectvalue;
    }

    private void Update()
    {
        if (isEscFalse)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= 20)
            {
                _currentTime = 0;
                IsWifiTrue = false;
            }
        }

        _mainvalue = (int)_MainmusicSlider.value;
        _effectvalue = (int)_EffectmusicSlider.value;

        _MainsoundText.text = $"{_mainvalue}";

        _EffectsoundText.text = $"{_effectvalue}";

        if (IsFireWallTrue == true)
        {
            _fireWallManager.texture = _basicFireWallSprtie;
            _fireWallManager.color = Color.green;
            _fireWallTrueText.color = Color.green;
            _fireWallTrueText.SetText("¿¬°áµÊ");
        }
        else if (IsFireWallTrue == false)
        {
            _fireWallManager.texture = _falseFireWallSprtie;
            _fireWallManager.color = Color.red;
            _fireWallTrueText.SetText("¿¬°á ¾ÈµÊ");
            _fireWallTrueText.color = Color.red;
        }

        if (IsWifiTrue == true)
        {
            _wifiCollectText.SetText("¿¬°áµÊ");
            _wifiCollectText.color = Color.green;
            _wifiAniamtion.enabled = true;
            _wifiAniamtion.gameObject.GetComponent<Image>().color = Color.white;
        }
        else if (IsWifiTrue == false)
        {
            _wifiRenderer.sprite = _falsewifiRenderer;
            _wifiCollectText.SetText("¿¬°á ¾ÈµÊ");
            _wifiCollectText.color = Color.red;
            _wifiAniamtion.enabled = false;
            _wifiAniamtion.gameObject.GetComponent<Image>().color = Color.gray;
        }
    }

    public void FireWall()
    {
        if (IsFireWallTrue == true)
        {
            IsFireWallTrue = false;
        }
        else
        {
            IsFireWallTrue = true;
        }
    }

    public void WifiTrue()
    {
        if (IsWifiTrue == true)
        {
            IsWifiTrue = false;
        }
        else
        {
            IsWifiTrue = true;
        }
    }
}
