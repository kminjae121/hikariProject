using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ObjectType
{
    box,
    ClothPress,
    BasicDoor,
    CloseDoor,
    Sofa,
    TwoFloorBed,
    ElectricFan,
    Ballon,
    WalkingDoll,
}
public class ObjectGarher : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType;

    
    private Rigidbody2D _playerRigidBody;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private int _jumpPower;
    [SerializeField] private LayerMask _player;


    private void Start()
    {
        _playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        ObjectAbility();    
    }

    private void ObjectAbility()
    {
        switch(_objectType)
        {
            case ObjectType.Sofa:
                Sofa();
                break;
            case ObjectType.ElectricFan:
                ElectricFan();
                break;
        }
    }

    private void ElectricFan()
    {
        
    }

    private void Sofa(float multiplier = 1f)
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0,_player);

        if (hit == true)
        {
            _playerRigidBody.velocity = Vector2.zero;
            _playerRigidBody.AddForce(Vector2.up * _jumpPower * multiplier, ForceMode2D.Impulse);
        }
    }
}
