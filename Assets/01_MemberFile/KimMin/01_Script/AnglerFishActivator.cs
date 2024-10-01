using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishActivator : MonoBehaviour
{
    private GameObject _anglerFish;

    private void Awake()
    {
        _anglerFish = GameObject.Find("AnglerFish");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _anglerFish.SetActive(true);
        }
    }
}
