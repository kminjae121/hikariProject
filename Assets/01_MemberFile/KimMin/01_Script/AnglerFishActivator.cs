using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishActivator : MonoBehaviour
{
    [SerializeField] private GameObject _anglerFish;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _anglerFish.SetActive(true);
        }
    }
}
