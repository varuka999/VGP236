using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody = null;
    [SerializeField] private Transform _lookTarget = null;
    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private InputAction _lookAction = null;

    [SerializeField] private float _moveSpeed = 0.0f;
    [SerializeField] private float _rotationSpeed = 0.0f;
    [SerializeField] private float _lookSensitivity = 0.0f;
    [SerializeField] private float _deadZone = 0.0f;
    [SerializeField] private float _maxLookRotation = 0.0f;
    [SerializeField] private float _minLookRotation = 0.0f;
    [SerializeField] private bool _invertY = false;
    private float _xRotation = 0.0f;


    public void Initialize()
    {
        if (_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        Debug.Assert(_rigidBody != null, $"{this} is missing a RigidBody");

        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _lookAction = _playerInput.Player.Look;

        Cursor.lockState = CursorLockMode.Locked;

        this.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _moveAction.Enable();
        _lookAction.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _moveAction.Disable();
        _lookAction.Disable();
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        // moveInput.x = left/right
        // moveInput.y = up/down
        // moveInput = joystick/dpad
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();

        Vector3 forward = _rigidBody.transform.forward;
        Vector3 right = _rigidBody.transform.right;

        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveVelo = (forward * moveInput.y * _moveSpeed) + (right * moveInput.x * _moveSpeed);
        moveVelo.y = _rigidBody.linearVelocity.y;

        _rigidBody.linearVelocity = moveVelo;
        _rigidBody.angularVelocity = Vector3.zero;
    }

    private void Look()
    {
        Vector2 lookInput = _lookAction.ReadValue<Vector2>();
        Vector2 lookDelta = Vector2.zero;

        if (lookInput.sqrMagnitude > _deadZone * _deadZone)
        {
            lookDelta = lookInput * _lookSensitivity * Time.deltaTime;
        }

        Quaternion rotation = Quaternion.Euler(0.0f, lookDelta.x, 0.0f);
        rotation = _rigidBody.rotation * rotation;
        _rigidBody.MoveRotation(rotation);

        if (_invertY == true)
        {
            _xRotation += lookDelta.y;
        }
        else
        {
            _xRotation -= lookDelta.y;
        }

        _xRotation = Mathf.Clamp(_xRotation, _minLookRotation, _maxLookRotation);

        _lookTarget.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
    }
}
