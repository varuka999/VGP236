using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed = Vector3.zero;
    [SerializeField] private Rigidbody _rg = null;

    private void FixedUpdate()
    {
        _rg.angularVelocity = _rotationSpeed * Time.deltaTime;
    }

}
