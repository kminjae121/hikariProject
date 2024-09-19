using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminescentPlants : MonoBehaviour
{
    [SerializeField] private Transform _playerTrm;
    public bool _isReach;
    public bool _isHold;

    public Action OnPlants;
    private Rigidbody2D _rigidCompo;

    private Rigidbody2D _playerRigidCompo;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HoldPlants(_playerTrm);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isReach = false;
    }

    private void HoldPlants(Transform parent)
    {
        if (_isReach == true && !_isHold && Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.SetParent(parent);
            _rigidCompo.bodyType = RigidbodyType2D.Kinematic;
            PlantRenderer();    
            _isHold = true;
        }

        else if (_isHold == true && Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.SetParent(null);
            _rigidCompo.bodyType = RigidbodyType2D.Dynamic;
            _isHold = false;
        }

        if (_isHold == true)
        {
            OnPlants?.Invoke();
        }
    }

    private void PlantRenderer()
    {
        transform.position = new Vector2(_playerTrm.position.x - 0.3f, _playerTrm.position.y);

        _playerRigidCompo = GetComponentInParent<Rigidbody2D>();

        if (_playerRigidCompo.velocity.x > 0)
        {
            transform.localScale = transform.localScale = new Vector3(transform.localScale.x, -1 * Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
    }
}
