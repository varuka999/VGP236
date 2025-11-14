using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    private MouseClick _inputActions = null;
    private InputAction _clickAction = null;

    private void Awake()
    {
        _inputActions = new MouseClick();
        _clickAction = _inputActions.Mouse.Click;
        _clickAction.performed += OnMouseClick;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _clickAction.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _clickAction.Disable();
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
            }
        }
    }
}