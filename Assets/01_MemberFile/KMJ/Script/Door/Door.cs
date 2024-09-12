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
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;
    [SerializeField] private DoorType _doorType;

    private int _currentSceneIndex;
    public List<GameObject> Stage = new List<GameObject>();
    public bool _isOpen;
    private static int _value;


    private void Awake()
    {
        _isOpen = false;
    }


    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                foreach (var StageList in Stage)
                {
                    Stage[_value].SetActive(true);
                    Stage[_value -= 1].SetActive(false);

                    _value++;
                }
            }
        }
    }

    private void LockDoor()
    {
        int Value = 1;
        Collider2D hit = Physics2D.OverlapBox(_doorTransform.position, _boxSize, 0, _player);

        if (hit == true)
        {
            if (_isOpen == true && Input.GetKeyDown(KeyCode.F))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    foreach (var StageList in Stage)
                    {
                        Stage[Value].SetActive(true);

                        Value += 1;
                    }
                }
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
