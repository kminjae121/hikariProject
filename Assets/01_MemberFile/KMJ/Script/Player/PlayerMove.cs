using DG.Tweening;
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

    public Sequence mySequence;

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
        mySequence = DOTween.Sequence()
                        .Append(transform.DOMoveX(transform.position.x + 0.3f, 0.1f))
                        .Append(transform.DOMoveX(transform.position.x - 0f, 0.1f))
                        .AppendInterval(1f)
                        .SetLoops(-1, LoopType.Yoyo)
                        .SetAutoKill(false);
        
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
