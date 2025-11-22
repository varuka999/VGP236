using Unity.Cinemachine;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private GroundCheck _groundCheck = null;
    [SerializeField] private Rigidbody _rigidBody = null;
    [SerializeField] private Transform _lookTarget = null;
    [SerializeField] private float _moveSpeed = 0.0f;
    [SerializeField] private float _jumpSpeed = 0.0f;
    [SerializeField] private float _mouseSensitivity = 0.0f;
    private float _deadZone = 0.1f;

    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private InputAction _jumpAction = null;
    private InputAction _lookAction = null;

    private Vector3 _moveVelocity = Vector3.zero;
    private Vector2 _lookVelocity = Vector2.zero;
    private float _xRotation = 0.0f;
    [SerializeField] bool _invertY = false;

    private void Awake()
    {
        if (_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _jumpAction = _playerInput.Player.Jump;
        _lookAction = _playerInput.Player.Look;

        _jumpAction.performed += OnJump;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
            CinemachineCamera cinemachineCamera = brain.ActiveVirtualCamera as CinemachineCamera;
            
            if (cinemachineCamera != null)
            {
                cinemachineCamera.Follow = _lookTarget;
            }
        }
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _moveAction.Enable();
        _jumpAction.Enable();
        _lookAction.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _moveAction.Disable();
        _jumpAction.Disable();
        _lookAction.Disable();
    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        _moveVelocity = transform.forward * moveInput.y * _moveSpeed + transform.right * moveInput.x * _moveSpeed;
        _moveVelocity.y = _rigidBody.linearVelocity.y;

        Vector2 lookInput = _lookAction.ReadValue<Vector2>();
        if (lookInput.magnitude < _deadZone)
        {
            _lookVelocity = Vector2.zero;
        }
        _lookVelocity = lookInput * _mouseSensitivity * Time.deltaTime;

        if (_invertY == true)
        {
            _xRotation += lookInput.y;
        }
        else
        {
            _xRotation -= lookInput.y;
        }
        _xRotation = Mathf.Clamp(_xRotation, -70f, 70.0f);
        _lookTarget.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);

        _rigidBody.linearVelocity = _moveVelocity;
        _rigidBody.angularVelocity = Vector3.zero;
        Quaternion rotation = _rigidBody.rotation * Quaternion.Euler(0.0f, _lookVelocity.x, 0.0f);
        _rigidBody.MoveRotation(rotation);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!IsOwner)
        {
            return;
        }

        if (_groundCheck.IsGrounded && _rigidBody.linearVelocity.y < 0.1f)
        {
            Debug.Log("Jumping");
            Vector3 velocity = _rigidBody.linearVelocity;
            velocity.y = _jumpSpeed;
            _rigidBody.linearVelocity = velocity;
        }
    }
}
