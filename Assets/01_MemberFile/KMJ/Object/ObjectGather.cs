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
    private bool _IsSofa;
    private bool _IsElectricFan;
    private bool _IsWalkintDool;
    private bool _isBallon;
    private bool _isUp;
    private Collider2D hit;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private int _jumpPower;
    [SerializeField] private int _flyingSpeed;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Transform _overlapPlace;


    private void Awake()
    {
        _IsSofa = false;
        _IsElectricFan = false;
        _IsWalkintDool = false;
    }

    private void Start()
    {
        _playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        ObjectAbility();
        _isUp = true;
    }


    private void Update()
    {

        hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);

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
                    _playerRigidBody.velocity = Vector2.zero;
                    _playerRigidBody.gravityScale = 3.14f;
                    _isUp = true;
                }
            }

        }
    }


    private void WalkingDoll(float multiplier = 1f)
    {
        if (hit != true)
        {
            _rigid.velocity = Vector2.zero;
        }
        else if (hit == true)
        {
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector2.right * _flyingSpeed * multiplier, ForceMode2D.Impulse);
        }
    }

    private void ElectricFan(float multiplier = 1f)
    {
        if (hit == true)
        {
            _playerRigidBody.gravityScale = 0;
            _playerRigidBody.velocity = Vector2.zero;
            _playerRigidBody.AddForce(Vector2.right * _flyingSpeed * multiplier, ForceMode2D.Impulse);
        }
        else
        {
            _playerRigidBody.gravityScale = 1;
        }
    }

    private void Sofa(float multiplier = 1f)
    {
        if (hit == true)
        {
            _playerRigidBody.velocity = Vector2.zero;
            _playerRigidBody.AddForce(Vector2.up * _jumpPower * multiplier, ForceMode2D.Impulse);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_overlapPlace.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
