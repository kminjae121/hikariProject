using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private InputReader _inputReader;
    [field: SerializeField] public int _moveSpeed { get; set; }
    [SerializeField] private int _jumpSpeed;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private ButtonMnager _buttonManager;

    private bool _isSecondJump;
    public bool _isJump { get; set; }
    public Rigidbody2D _rigid { get; set; }
    private Vector2 _xmove;

    private void Awake()
    {
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
        _isJump = Physics2D.OverlapBox(_groundChecker.position,
                _boxSize, 0, _whatIsGround);

        SetMove(_inputReader.Movement.x);
    }

    private void SetMove(float Xmove)
    {
        _xmove.x = Xmove;
    }

    private void Jump()
    {
        if (_isJump == true)
        {
            _rigid.velocity = Vector2.zero;

            _rigid.AddForce(Vector2.up * _jumpSpeed * 1, ForceMode2D.Impulse);

            _isSecondJump = true;
        }

        else if (_isSecondJump == true)
        {
            _rigid.velocity = Vector2.zero;
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
        _rigid.velocity = new Vector2(_xmove.x * _moveSpeed, _rigid.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundChecker.position, _boxSize);
        Gizmos.color = Color.white;
    }
}
