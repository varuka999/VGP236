using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerDestination : MonoBehaviour
{
    static private PlayerDestination _instance;

    public UnityEvent<Vector3> OnMouseClickEvent;
    private MouseClick _inputActions = null;
    private InputAction _clickAction = null;

    [SerializeField] private float _gizmoRadius = 1.0f;
    [SerializeField] private Color _gizmoColor = Color.green;

    static public PlayerDestination Instance { get => _instance; }

    public void Initialize(PlayerController _player)
    {
        if (_instance == null)
        {
            _instance = new PlayerDestination();
        }

        _inputActions = new MouseClick();
        _clickAction = _inputActions.Mouse.Click;
        _clickAction.performed += OnMouseClick;

        _inputActions.Enable();
        _clickAction.Enable();

        //OnMouseClickEvent.AddListener(_player.SetDestination);
    }

    private void OnEnable()
    {
        if (_inputActions != null)
        {
            _inputActions.Enable();
            _clickAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (_inputActions != null)
        {
            _inputActions.Disable();
            _clickAction.Disable();
        }

        OnMouseClickEvent.RemoveAllListeners();
    }

    void OnMouseClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(cameraRay, out hitInfo, 100.0f) == true)
        {
            if (hitInfo.collider != null)
            {
                transform.position = hitInfo.point;

                if (OnMouseClickEvent != null)
                {
                    //OnMouseClickEvent?.Invoke(this.transform.position);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.position, _gizmoRadius);
    }
}
