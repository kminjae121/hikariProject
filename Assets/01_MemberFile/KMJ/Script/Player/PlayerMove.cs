using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private InputReader _inputReader;
    [field: SerializeField] public int _moveSpeed { get; set; }
    [field: SerializeField] public int _jumpSpeed { get; set; }
    [field: SerializeField] public int _swimSpeed { get; set; }
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsObject;

    [SerializeField] private ButtonManager _buttonManager;

    [field: SerializeField] public bool isSwimming { get; set; }

    private static bool _isWalk;
    private bool _isSecondJump;
    [field : SerializeField] public bool _isJump { get; set; }
    public bool _isForce;
    public bool _isVine;
    public Rigidbody2D _rigid { get; set; }
    private Vector2 _xmove;

    private void Awake()
    {
        isSwimming = false;
        _isJump = true;
        _inputReader.JumpKeyEvent += Jump;
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }
    private void OnDestroy()
    {
        _inputReader.JumpKeyEvent -= Jump;
    }

    private void Update()
    {
        if (!_isVine)
        {
            _isJump = Physics2D.OverlapBox(_groundChecker.position,
                    _boxSize, 0, _whatIsGround);
        }
        SetMove(_inputReader.Movement.x);
    }

    private void Swimming(int SwimSpeed)
    {
        _rigid.velocity = new Vector2(Vector2.right.x * SwimSpeed, _rigid.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.velocity = new Vector2(0, _rigid.velocity.y * _jumpSpeed);
        }
    }

    private void SetMove(float Xmove)
    {
        _xmove.x = Xmove;
    }

    private void Jump()
    {
        if (_isJump == true && !_isVine)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 0);

            _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            _isSecondJump = true;
        }

        else if (_isSecondJump == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x,0);

            _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);

            _isSecondJump = false;
        }
    }


    public void PlayerMovement(float MoveSpeed)
    {
        _rigid.velocity = new Vector2(_xmove.x * MoveSpeed, _rigid.velocity.y);
    }


    private void FixedUpdate()
    {
        if(!_isForce && OpenControlPanel._isTrue == true)
        {
            if (isSwimming)
                Swimming(_swimSpeed);
            else
                PlayerMovement(_moveSpeed);
        }

        if (OpenControlPanel._isTrue == true)
            _rigid.velocity = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundChecker.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
