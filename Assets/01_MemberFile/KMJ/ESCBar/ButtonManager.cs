using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    private int _mainvalue;
    private int _effectvalue;

    [SerializeField] private GameObject _esc;
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private Button _brightButton;
    [Header("��ȭ��")]
    [SerializeField] private TextMeshProUGUI _fireWallTrueText;
    [SerializeField] private Texture _basicFireWallSprtie;
    [SerializeField] private Texture _falseFireWallSprtie;
    [SerializeField] private RawImage _fireWallManager;
    public bool IsFireWallTrue;
    [Header("Wifi")]
    [SerializeField] private TextMeshProUGUI _wifiCollectText;
    [SerializeField] private SpriteRenderer _wifiRenderer;
    [field :SerializeField] public bool IsWifiTrue { get; set; }
    [SerializeField] private Animator _wifiAniamtion;
    [Header("Sound")]
    [SerializeField] private TextMeshProUGUI _MainsoundText;
    [SerializeField] private Slider _MainmusicSlider;

    [SerializeField] private TextMeshProUGUI _EffectsoundText;
    [SerializeField] private Slider _EffectmusicSlider;

    [Header("ButtonList")]
    public List<GameObject> ChangeButton = new List<GameObject>();
    public int SceneNumber;

    private void Awake()
    {
        _esc.SetActive(false);
        IsWifiTrue = false;
        IsFireWallTrue = false;
        _brightButton.interactable = false;
    }

    private void Start()
    {
        _fireWallTrueText.text = "���� �ȵ�";
        _wifiCollectText.text = "���� �ȵ�";

    }

    private void Update()
    {
        _mainvalue = (int)_MainmusicSlider.value;
        _effectvalue = (int)_EffectmusicSlider.value;

        InteractablFalse();

        _MainsoundText.text = $"{_mainvalue}";

        _EffectsoundText.text = $"{_effectvalue}";

        if (IsFireWallTrue == true)
        {
            _fireWallManager.texture = _basicFireWallSprtie;
            _fireWallManager.color = Color.green;
            _fireWallTrueText.color = Color.green;
            _fireWallTrueText.SetText("�����");
        }
        else if (IsFireWallTrue == false )
        {
            _fireWallManager.texture = _falseFireWallSprtie;
            _fireWallManager.color = Color.red;
            _fireWallTrueText.SetText("���� �ȵ�");
            _fireWallTrueText.color = Color.red;
        }

        if (IsWifiTrue == true)
        {
            _wifiCollectText.SetText("�����");
            _wifiCollectText.color = Color.green;
            _wifiAniamtion.enabled = true;
        }
        else if (IsWifiTrue == false)
        {
            _wifiCollectText.SetText("���� �ȵ�");
            _wifiCollectText.color = Color.red;
            _wifiAniamtion.enabled = false;
        }
    }

    private void InteractablFalse()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            _brightButton.interactable = true;
        }
        else
        {
            _brightButton.interactable = false;
        }
    }

    public void FireWall()
    {
        if(IsFireWallTrue == true)
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
