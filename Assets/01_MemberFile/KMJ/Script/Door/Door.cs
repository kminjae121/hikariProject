using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public enum DoorType
{
    Normal,
    lockdoor,
}
public class Door : MonoBehaviour
{
    private PlayerKeyFalse _playerKeyFalse;
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;
    [SerializeField] private DoorType _doorType;

    public static int _currentSceneIndex =1;
    public bool _isOpen;
    public bool _isClear;


    private void Awake()
    {
        _playerKeyFalse = GameObject.Find("PlayerPrefab").GetComponent<PlayerKeyFalse>();
        _isOpen = false;
    }

    private void LateUpdate()
    {
        if (_doorType == DoorType.Normal)
        {
            NormalDoor();
        }
        else if(_doorType == DoorType.lockdoor)
        {
            LockDoor();
        }
    }

    private void NormalDoor()
    {
        Collider2D hit = Physics2D.OverlapBox(_doorTransform.position, _boxSize, 0, _player);

        if (hit == true)
        {
            if(_currentSceneIndex == 5)
            {
                return;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                ObjectGather.maxMoveDoolDistance = 6;
                SceneManager.LoadScene($"CaptureStage{_currentSceneIndex += 1}");
            }
            else if(_currentSceneIndex >= 3)
            {
                _playerKeyFalse.blockKey = true;
            }
        }
    }

    private void LockDoor()
    {
        Collider2D hit = Physics2D.OverlapBox(_doorTransform.position, _boxSize, 0, _player);

        if (hit == true)
        {
            if (_isOpen == true && Input.GetKeyDown(KeyCode.F))
            {
                ObjectGather.maxMoveDoolDistance = 6;
                SceneManager.LoadScene($"CaptureStage{_currentSceneIndex += 1}");
            }
            else if (_currentSceneIndex == 5 && _isOpen == true && Input.GetKeyDown(KeyCode.F))
            {
                //SceneManager.LoadScene("¥Ÿ¿Ω æ¿");
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_doorTransform.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
