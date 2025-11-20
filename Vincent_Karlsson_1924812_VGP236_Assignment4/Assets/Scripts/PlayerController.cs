using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;

    private MouseClick _inputActions = null;
    private InputAction _clickAction = null;

    public void Initialize()
    {
        //PlayerDestination.OnMouseClickEvent.AddListener(SetDestination);
        //PlayerDestination.OnMouseClickEvent += SetDestination;

        _inputActions = new MouseClick();
        _clickAction = _inputActions.Mouse.Click;
        _clickAction.performed += OnMouseClick;

        _inputActions.Enable();
        _clickAction.Enable();

        if (_agent == null)
        {
            _agent = this.GetComponent<NavMeshAgent>();
        }
    }

    private void Update()
    {

    }

    public void SetDestination(Vector3 destination)
    {
        //_agent.SetDestination(destination);
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
                SetDestination(hitInfo.point);
                //DrawGizmos(hitInfo.point);
            }
        }
    }

    private void DrawGizmos(Vector3 drawpoint)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(drawpoint, 0.5f);
    }
}
