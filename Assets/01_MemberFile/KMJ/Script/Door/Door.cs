using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum DoorType
{
    Normal,
    lockdoor,
}
public class Door : MonoBehaviour
{
    private StageManager _stageManager;
    private PlayerKeyFalse _playerKeyFalse;
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;
    [SerializeField] private DoorType _doorType;
    private ButtonManager _btnManager;
    private StageText _stageText;

    private GameObject _esc;

    public static int _currentSceneIndex = 0;
    public bool _isOpen;
    public bool _isClear;


    private void Awake()
    {         _stageText = GameObject.Find("StageManager").GetComponent<StageText>();

        _esc = GameObject.Find("EscCanvas");
        _stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();

        _playerKeyFalse = GameObject.Find("PlayerPrefab").GetComponent<PlayerKeyFalse>();

        _isOpen = false;
    }

    private void Start()
    {
        _btnManager = GameObject.Find("EscParent").GetComponent<ButtonManager>();
    } 

    private void Update()
    {
    }

    private void TextOpen()
    {

    }

    private void LateUpdate()
    {
        if (_doorType == DoorType.Normal)
        {
            NormalDoor();
            NextStage();
        }
        else if (_doorType == DoorType.lockdoor)
        {
            LockDoor();
            NextStage();
        }
    }

    private void NormalDoor()
    {
        Collider2D hit = Physics2D.OverlapBox(_doorTransform.position, _boxSize, 0, _player);

        if (hit == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ObjectGather.maxMoveDoolDistance = 6;

                GameObject[] CloneObjects = FindObjectsOfType<GameObject>();

                foreach (GameObject Cloneobj in CloneObjects)
                {
                    if (Cloneobj.name.Contains("Clone"))
                    {
                        Cloneobj.SetActive(false);
                    }
                }
            }
        }
    }

    private void LockDoor()
    {
        Collider2D hit = Physics2D.OverlapBox(_doorTransform.position, _boxSize, 0, _player);

        if (hit == true)
        {
            if (_isOpen == true && Input.GetKey(KeyCode.F))
            {
                ObjectGather.maxMoveDoolDistance = 6;
                _currentSceneIndex += 1;
            }
            else if (_currentSceneIndex == 5 && _isOpen == true && Input.GetKeyDown(KeyCode.F))
            {
                //SceneManager.LoadScene("¥Ÿ¿Ω æ¿");
            }
        }
    }

    private void NextStage()
    {
        Collider2D hit = Physics2D.OverlapBox(_doorTransform.position, _boxSize, 0, _player);

        if(hit == true)
        {
            if (Input.GetKey(KeyCode.F) && _currentSceneIndex != 5)
            {
                PlayerChatBoxManager.Instance.End();
                _stageManager.stageList[_currentSceneIndex].SetActive(false);
                _stageManager.stageList[_currentSceneIndex += 1].SetActive(true);
                _playerKeyFalse.transform.GetComponent<PlayerMove>()._isForce = false;
            }
            else if (Input.GetKey(KeyCode.F) && _currentSceneIndex == 5)
                SceneManager.LoadScene("EndingScene");
                

        }
        if (_currentSceneIndex == 5)
        {
            _playerKeyFalse.blockKey = false;
            return;
        }

        if (_currentSceneIndex == 3)
            {
                _playerKeyFalse.blockKey = true;
            }
            else if (_currentSceneIndex == 4)
            {
                _btnManager.isEscFalse = true;
            }
            else
            {
                _btnManager.isEscFalse = false;
            }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_doorTransform.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
