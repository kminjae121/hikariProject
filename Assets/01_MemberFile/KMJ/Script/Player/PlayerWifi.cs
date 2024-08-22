using DG.Tweening;
using UnityEngine;

public class PlayerWifi : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _falseSprite;
    [SerializeField] private ButtonMnager _buttonManager;
    [SerializeField] private PlayerMove _playerMove;
    private SpriteRenderer _spriteCompo;

    private void Awake()
    {
        _spriteCompo = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        WifiTrue(_buttonManager.IsWifiTrue);
    }

    private void WifiTrue(bool IsWifi)
    {
        if (IsWifi == true)
        {
            _spriteCompo.sprite = _sprite;
            _spriteCompo.color = Color.green;
        }
        else if (IsWifi == false)
        {
            _spriteCompo.sprite = _falseSprite;
            _spriteCompo.color = Color.red;
        }
    }

    private bool Buffering(bool IsWifi)
    {
        _playerMove.mySequence.OnPlay(() => IsWifi = false);

        Debug.Log("æ∆¿’ ª–");

        _playerMove.mySequence.OnPause(() => IsWifi = true);

        Debug.Log("æ∆¿’ ª–");

        return IsWifi;
    }

    private void FixedUpdate()
    {
        Buffering(_buttonManager.IsWifiTrue);
    }
}
