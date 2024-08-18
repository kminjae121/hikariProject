using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminescentPlants : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool isReach;
    public bool isHold;

    public Action OnPlants;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HoldPlants(player);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isReach = false;
    }

    private void HoldPlants(Transform parent)
    {
        if (isReach == true && Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.SetParent(parent);
            isHold = true;
            rigid.bodyType = RigidbodyType2D.Kinematic;
        }

        if (isHold == true && Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.SetParent(null);
            //rigid.bodyType = RigidbodyType2D.Dynamic;
            isHold = false;
        }

        if (isHold == true)
        {
            OnPlants?.Invoke();
        }
    }
}
