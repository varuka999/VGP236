using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation = null;
    private PlayerInput _playerInput = null;
    private InputAction _moveInputAction = null;
    private InputAction _jumpInputAction = null;
    [SerializeField] private Rigidbody2D _rg2D = null;
    [SerializeField] private GroundCheck _groundCheck = null;

    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _jumpSpeed = 30.0f;

    public float MoveSpeed { get => _moveSpeed; }

    private void Awake()
    {
        if (_rg2D == null)
        {
            _rg2D = this.gameObject.GetComponent<Rigidbody2D>();
        }

        _playerInput = new PlayerInput();

        if (this.gameObject.tag == "Player1")
        {
            _moveInputAction = _playerInput.Player1.Move;
            _jumpInputAction = _playerInput.Player1.Jump;
        }
        else if (this.gameObject.tag == "Player2")
        {
            _moveInputAction = _playerInput.Player2.Move;
            _jumpInputAction = _playerInput.Player2.Jump;
        }

        _jumpInputAction.performed += OnJump;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _moveInputAction.Enable();
        _jumpInputAction.Enable();
    }
    private void OnDisable()
    {
        _playerInput.Disable();
        _moveInputAction.Disable();
        _jumpInputAction.Disable();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = _moveInputAction.ReadValue<Vector2>();
        _rg2D.linearVelocityX = moveInput.x * _moveSpeed;

        _playerAnimation.UpdateAnimations(moveInput.x);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded == true)
        {
            _rg2D.linearVelocityY = _jumpSpeed;
        }
    }

    public Vector2 GetMovementInput()
    {
        return _moveInputAction.ReadValue<Vector2>();
    }
}
