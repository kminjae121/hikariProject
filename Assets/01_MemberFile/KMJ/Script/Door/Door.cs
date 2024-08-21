using UnityEngine;
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

    public bool _isOpen;


    private void Awake()
    {
        _isOpen = false;
    }


    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
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
                SceneManager.LoadScene(_currentSceneIndex += 1);
                Debug.Log("´ÙÀ½ ¾À ¾øÀ½");
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
                SceneManager.LoadScene(_currentSceneIndex += 1);
                Debug.Log("´ÙÀ½ ¾À ¾øÀ½");
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
