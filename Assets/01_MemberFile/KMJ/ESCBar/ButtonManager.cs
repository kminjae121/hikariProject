using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    private int _value;

    [SerializeField] private GameObject _esc;
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private Button _brightButton;
    [Header("¹æÈ­º®")]
    [SerializeField] private TextMeshProUGUI _fireWallTrueText;
    [SerializeField] private Texture _basicFireWallSprtie;
    [SerializeField] private Texture _falseFireWallSprtie;
    [SerializeField] private RawImage _fireWallManager;
    public bool IsFireWallTrue;
    [Header("Wifi")]
    [SerializeField] private TextMeshProUGUI _wifiCollectText;
    [field :SerializeField] public bool IsWifiTrue { get; set; }
    [SerializeField] private Animator _wifiAniamtion;
    [Header("Sound")]
    [SerializeField] private TextMeshProUGUI _soundText;
    [SerializeField] private Slider _musicSlider;

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
        _fireWallTrueText.text = "¿¬°á ¾ÈµÊ";
        _wifiCollectText.text = "¿¬°á ¾ÈµÊ";

    }

    private void Update()
    {
        _value = (int)_musicSlider.value;


        InteractablFalse();

        _soundText.text = $"{_value}";

        if (IsFireWallTrue == true)
        {
            _fireWallManager.texture = _basicFireWallSprtie;
            _fireWallManager.color = Color.green;
            _fireWallTrueText.color = Color.green;
            _fireWallTrueText.SetText("¿¬°áµÊ");
        }
        else if (IsFireWallTrue == false )
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
        }
        else if (IsWifiTrue == false)
        {
            _wifiCollectText.SetText("¿¬°á ¾ÈµÊ");
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
