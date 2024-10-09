using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFKey : MonoBehaviour
{
    [SerializeField] private GameObject _fKey;
    [SerializeField] private KeyPuzzle _keyPuzzle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_keyPuzzle.hasKey)
                _fKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _fKey.SetActive(false);
        }
    }
}
