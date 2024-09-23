using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

enum ObjectType
{
    None,
    Sofa,
    ElectricFan,
    Ballon,
    WalkingDoll,
    NoneObject,
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
    private bool _isNone;
    private bool _isDraw;
    private CaptureObject _captureObj;

    public  float maxMoveDoolDistance = 6;

    private Transform _playerCam;
    private Transform _playerCamTransform;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private int _jumpPower;
    [SerializeField] private int _flyingSpeed;
    [SerializeField] private int _downPower;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _GroundLayer;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Transform _overlapPlace;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _player;
    private PlayerMove _playermove;

    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _groundCheckerSize;

    private void Awake()
    { 
        _playerCam = GameObject.Find("PlayerCam").transform;
        _IsSofa = false;
        _IsElectricFan = false;
        _IsWalkintDool = false;
        _isBallon = false;
    }

    private void Start()
    {
        _captureObj = GetComponent<CaptureObject>();
        _playermove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();
        _playerRigidBody = GameObject.Find("PlayerPrefab").GetComponent<Rigidbody2D>();
        _player = GameObject.Find("PlayerPrefab").transform;
        ObjectAbility();
        _isUp = true;
    }


    private void Update()
    {

        Debug.Log(maxMoveDoolDistance);
        if (_IsSofa == true)
        {
            Collider2D hitter = Physics2D.OverlapBox(_groundChecker.position, _groundCheckerSize, 0, _GroundLayer);

            if (hitter == false)
            {
                StartCoroutine(Down());
                if (hitter == true)
                {
                }
            }
            Sofa();
            _isDraw = true;
        }

        if (_IsWalkintDool == true)
        {
            WalkingDoll();
            _isDraw = true;
        }

        if (_IsElectricFan == true)
        {
            Collider2D hitter = Physics2D.OverlapBox(_groundChecker.position, _groundCheckerSize, 0, _GroundLayer);

            if (hitter == false)
            {
                StartCoroutine(Down());
                if (hitter == true)
                {
                }
            }
            ElectricFan();
            _isDraw = true;
        }

        if (_isBallon == true)
        {
            Ballon();
            _isDraw = true;
        }
        
        if(_isNone == true)
        {
            Collider2D hitter = Physics2D.OverlapBox(_groundChecker.position, _groundCheckerSize, 0, _GroundLayer);

            if (hitter == false)
            {
                StartCoroutine(Down());
            }
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
            case ObjectType.None:
                _isNone = true;
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
                    _playermove.enabled = false;
                    _captureObj.enabled = false;
                    _playerRigidBody.mass = 0.0001f;
                }
                else if (_isUp == false)
                {
                    _playerRigidBody.gravityScale = 3.14f;
                    _isUp = true;
                    _playermove.enabled = true;
                    _captureObj.enabled = true;
                    _playerRigidBody.mass = 1f;
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

        else if (hit == true && maxMoveDoolDistance >= 0)
        {
            animator.SetBool("Walk", true);
            _rigid.velocity = Vector2.zero;
            _rigid.AddForce(Vector2.right * _flyingSpeed * multiplier, ForceMode2D.Impulse);

            maxMoveDoolDistance -= Time.deltaTime;
        }
    }

    private void ElectricFan()
    { 

        Collider2D hit = Physics2D.OverlapBox(_overlapPlace.position, _boxSize, 0, _playerLayer);

        if (hit == true)
        {
            _playerRigidBody.velocity = Vector2.zero;
            _player.position = Vector2.MoveTowards(_player.position, _endPosition.position, _flyingSpeed * Time.deltaTime);
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

    private IEnumerator Down()
    {
        yield return new WaitForSeconds(1.3f);

        _rigid.AddForce(Vector2.down * _downPower, ForceMode2D.Impulse);
        _playerCam.DOShakePosition(0.01f,0.013f);
    }

    public void OnDrawGizmos()
    {
        if (_isDraw == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_overlapPlace.position, _boxSize);
            Gizmos.color = Color.white;
        }
        else if(_objectType == ObjectType.None || _objectType == ObjectType.Sofa || _objectType == ObjectType.ElectricFan)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(_groundChecker.position, _groundCheckerSize);
            Gizmos.color = Color.white;
        }
            return;
    }
}
