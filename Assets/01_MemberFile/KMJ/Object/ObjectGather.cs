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
public class ObjectGather : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType;


    private Rigidbody2D _playerRigidBody;
    private bool _IsSofa;
    private bool _IsElectricFan;
    private bool _IsWalkintDool;
    private bool _isBallon;
    private bool _isUp;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private int _jumpPower;
    [SerializeField] private int _flyingSpeed;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Transform _overlapPlace;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _player;
    private PlayerMove _playermove;

    private void Awake()
    {
        _IsSofa = false;
        _IsElectricFan = false;
        _IsWalkintDool = false;
        _isBallon = false;
    }

    private void Start()
    {
        _playermove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();
        _playerRigidBody = GameObject.Find("PlayerPrefab").GetComponent<Rigidbody2D>();
        _player = GameObject.Find("PlayerPrefab").transform;
        ObjectAbility();
        _isUp = true;
    }


    private void Update()
    {

        if (_IsSofa == true)
        {
            Sofa();
        }

        if (_IsWalkintDool == true)
        {
            WalkingDoll();
        }

        if (_IsElectricFan == true)
        {
            ElectricFan();
        }

        if (_isBallon == true)
        {
            Ballon();
        }
    }

    private void ObjectAbility()
    {
        switch (_objectType)
        {
            case ObjectType.Sofa:
                _IsSofa = true;
                break;
            case ObjectType.ElectricFan:
                _IsElectricFan = true;
                break;
            case ObjectType.WalkingDoll:
                _IsWalkintDool = true;
                break;
            case ObjectType.Ballon:
                _isBallon = true;
                break;
        }
    }

    private void Ballon()
    {
        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);
        if (hit == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_isUp == true)
                {
                    _rigid.gravityScale = -0.5f;
                    _playerRigidBody.gravityScale = -0.5f;
                    _isUp = false;
                }
                else if(_isUp  == false)
                {
                    _playerRigidBody.gravityScale = 3.14f;
                    _isUp = true;
                }
            }

        }
    }


    private void WalkingDoll(float multiplier = 1f)
    {
        Animator animator = GetComponent<Animator>();

        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);
        if (hit != true)
        {
            animator.SetBool("Walk", false);
            _rigid.velocity = Vector2.zero;
        }

        else if (hit == true)
        {
            animator.SetBool("Walk", true);
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector2.right * _flyingSpeed * multiplier, ForceMode2D.Impulse);
        }
    }

    private void ElectricFan()
    {
        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);
        if (hit == true)
        {
            _playerRigidBody.gravityScale = 0;
            _playerRigidBody.velocity = Vector2.zero;
            _player.position = Vector2.MoveTowards(_player.position,_endPosition.position, _flyingSpeed * Time.deltaTime);
        }
        else
        {
            _playerRigidBody.gravityScale = 3.14f;
        }
    }

    private void Sofa(float multiplier = 1f)
    {
        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);
        if (hit == true)
        {
            _playerRigidBody.velocity = Vector2.zero;
            _playerRigidBody.AddForce(Vector2.up.normalized * _jumpPower * multiplier, ForceMode2D.Impulse);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_overlapPlace.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
