using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyFalse : MonoBehaviour
{
    private int _randNum;
    [field:SerializeField] public bool blockKey { get; set; }
    private PlayerMove _playerMove;

    private void Awake()
    {
        blockKey = false;
        _randNum = Random.Range(1,3);
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        Debug.Log(_randNum);
        if(_randNum == 1)
        {
            Debug.Log("Á¡ÇÁ ºÀ¼â");
        }
        else if(_randNum == 2)
        {
            Debug.Log("Esc ºÀ¼â");
        }
    }
    private void Update()
    {
        BlockKey(8,0);

    }

    private void BlockKey(int OriginJumpPower, int BlockJump)
    {
        if (blockKey == true)
        {
            switch (_randNum)
            {
                case 1:
                    _playerMove._jumpSpeed = BlockJump;
                    break;
                //case 2:
                    //OpenControlPanel._isTrue = false;
                   // break;
            }
        }
        else
        {
            OpenControlPanel._isTrue = true;
            _playerMove._jumpSpeed = OriginJumpPower;
        }
    }
}
