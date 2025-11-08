using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed = Vector3.zero;
    [SerializeField] private Rigidbody _rigidBody = null;

    private void FixedUpdate()
    {
        _rigidBody.angularVelocity = _rotationSpeed * Time.deltaTime;
    }

}
