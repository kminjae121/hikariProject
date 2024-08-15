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
    [SerializeField] private int _flyingSpeed;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Rigidbody2D rigid;


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
            case ObjectType.WalkingDoll:
                WalkingDoll();
                break;
        }
    }

    private void WalkingDoll(float multiplier = 1f)
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, _boxSize, 0);
        foreach(Collider2D Stop in hit)
        {
            if(Stop.gameObject.layer != _playerLayer)
            {
                rigid.velocity = new Vector3(0,0);
            }
        }
        rigid.AddForce(Vector2.right * _flyingSpeed * multiplier, ForceMode2D.Impulse); 
    }

    private void ElectricFan(float multiplier = 1f)
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0, _playerLayer);

        if(hit == true)
        {
            _playerRigidBody.gravityScale = 0;
            _playerRigidBody.AddForce(Vector2.right * _flyingSpeed * multiplier, ForceMode2D.Impulse);
        }
        else
        {
            _playerRigidBody.gravityScale = 1;
        }
    }

    private void Sofa(float multiplier = 1f)
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0,_playerLayer);

        if (hit == true)
        {
            _playerRigidBody.velocity = Vector2.zero;
            _playerRigidBody.AddForce(Vector2.up * _jumpPower * multiplier, ForceMode2D.Impulse);
        }
    }
}
