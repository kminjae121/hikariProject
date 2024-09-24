using UnityEngine;

public class PlayerKeyFalse : MonoBehaviour
{
    private int _randNum = 1;

    [field: SerializeField] public bool blockKey { get; set; }
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {

    } 
    private void Update()
    {
        if (Door._currentSceneIndex != 5 || Door._currentSceneIndex >= 3)
            BlockKey(8, 0);
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
            }
        }
        else
        {
            OpenControlPanel._isTrue = true;
            _playerMove._jumpSpeed = OriginJumpPower;
        }
    }
}
