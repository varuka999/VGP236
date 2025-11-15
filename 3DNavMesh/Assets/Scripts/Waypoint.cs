using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private float _gizmoRadius = 1.0f;
    [SerializeField] private Color _gizmoColor = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.position, _gizmoRadius);
    }
}
