using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private GameObject _player;


    private void Awake()
    {
        _player = GameObject.Find("PlayerPrefab");
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == _player.name)
        {
            ButtonManager.IsWifiTrue = false;
        }
    }
}
