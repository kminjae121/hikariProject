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

    private void Awake()
    {
        _key = GameObject.Find("Key");
        _keyHole = GameObject.Find("KeyHole");
        _keyPosition = GameObject.Find("KeyPosition").transform;

        _checkPlayer = _key.GetComponent<CheckPlayerCollide>();

        _checkPlayer.OnPlayerCollide += HandlePlayerCollide;
    }

    private void FixedUpdate()
    {
        if (hasKey)
        {
            FollowPlayer();
        }
    }

    private void HandlePlayerCollide()
    { 
        _key.transform.DOScale(0.5f, 0.5f);
        hasKey = true;
    }

    private void FollowPlayer()
    {
        _key.transform.position = Vector3.Lerp
            (_key.transform.position, _keyPosition.position, 0.05f);
    }
}
