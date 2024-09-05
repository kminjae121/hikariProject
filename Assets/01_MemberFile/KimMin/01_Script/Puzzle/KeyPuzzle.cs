using System;
using UnityEngine;
using DG.Tweening;

public class KeyPuzzle : MonoBehaviour
{
    private GameObject _key;
    private GameObject _keyHole;
    private Transform _keyPosition;
    private CheckPlayerCollide _checkPlayer;

    private float _keySpeed = 5f;
    private bool hasKey;
    private bool isHoleHit;

    private void Awake()
    {
        _key = GameObject.Find("Key");
        _keyPosition = GameObject.Find("KeyPosition").transform;
        _keyHole = GameObject.Find("KeyHole");

        _checkPlayer = _key.GetComponent<CheckPlayerCollide>();

        _checkPlayer.OnPlayerCollide += HandlePlayerCollide;
        _checkPlayer.OnKeyHoleCollide += HandleKeyHoleCollide;
    }

    private void HandleKeyHoleCollide()
    {
        isHoleHit = true;
    }

    private void HandlePlayerCollide()
    {
        _key.transform.DOScale(0.5f, 0.5f);
        hasKey = true;
    }

    private void FixedUpdate()
    {
        if (hasKey)
        {
            FollowPlayer();
        }
        else if (isHoleHit && hasKey)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnKeyEnter();
            }
        }
    }

    private void FollowPlayer()
    {
        _key.transform.position = Vector3.Lerp
            (_key.transform.position, _keyPosition.position, 0.05f);
    }

    private void OnKeyEnter()
    {
        hasKey = false;

        Destroy(_key);
        Debug.Log("Å° µé¾î¿È");
    }
}
