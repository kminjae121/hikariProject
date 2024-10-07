using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject _controlPanel;
    public static bool _isTrue;
    private PlayerAnimation _playerAnimator;
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerAnimator = GameObject.Find("PlayerAnimation").GetComponent<PlayerAnimation>();
        _playerMove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();
        _isTrue = true;
    }

    private void Start()
    {
        _isTrue = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isTrue == true)
        {
            _playerAnimator._isAnimator = false;
            _playerMove._isForce = true;
            _playerMove.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _isTrue = false;
            _controlPanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _isTrue == false)
        {
            _playerAnimator._isAnimator = true;
            _playerMove._isForce = false;
            _isTrue = true;
            _controlPanel.SetActive(false);
        }

        if(_isTrue == false)
        {
            _playerMove._isForce = true;
        }
    }
}
