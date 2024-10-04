using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class DownFloor : MonoBehaviour
{
    private GameObject _player;

    private Sequence colorFade;

    private void Awake()
    {
        _player = GameObject.Find("PlayerPrefab");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == _player.name)
        {
            transform.DOMoveY(-40, 2);
        }
    }
}
