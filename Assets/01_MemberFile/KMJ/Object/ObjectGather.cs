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
        }
    }

    private void WalkingDoll(float multiplier = 1f)
    {
        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);

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
        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);

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
        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);

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
