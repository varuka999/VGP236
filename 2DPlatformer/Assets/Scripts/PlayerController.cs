using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput = null;
    private InputAction _moveInputAction = null;
    private InputAction _jumpInputAction = null;
    [SerializeField] private Rigidbody2D _rg2D = null;
    [SerializeField] private GroundCheck _groundCheck = null;

    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _jumpSpeed = 30.0f;

    private void Awake()
    {
        if (_rg2D == null)
        {
            this.gameObject.GetComponent<Rigidbody2D>();
        }

        _playerInput = new PlayerInput();
        _moveInputAction = _playerInput.Player.Move;
        _jumpInputAction = _playerInput.Player.Jump;

        _jumpInputAction.performed += OnJump;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _moveInputAction.Enable();
        _jumpInputAction.Enable();
    }
    private void Update()
    {
        Vector2 moveInput = _moveInputAction.ReadValue<Vector2>();
        _rg2D.linearVelocityX = moveInput.x * _moveSpeed;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _moveInputAction.Disable();
        _jumpInputAction.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded == true)
        {
            _rg2D.linearVelocityY = _jumpSpeed;
        }
    }
}
