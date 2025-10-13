using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _obstacleRigidBody2D = null;

    private float _obstacleXScale = 0.0f;
    private float _obstacleYScale = 0.0f;
    private float _obstacleMass = 0.0f;
    [SerializeField] private float _obstacleMoveSpeed = 0.0f;
    private float _obstacleRotationSpeed = 0.0f;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x -= _obstacleMoveSpeed * Time.deltaTime;

        transform.position = position;
    }

    public void Initialize()
    {
        if (_obstacleRigidBody2D != null)
        {
            _obstacleXScale = Random.Range(0.3f, 0.5f);
            _obstacleYScale = Random.Range(0.3f, 0.6f);
            _obstacleMass = (_obstacleXScale * _obstacleYScale) * 100;
            _obstacleMoveSpeed = 3;
            _obstacleRotationSpeed = 0;
        }
        //else
        //{
        //    _obstacleXScale = 0.4f;
        //    _obstacleYScale = 0.5f;
        //    _obstacleMass = (_obstacleXScale * _obstacleYScale) * 100;
        //    _obstacleMoveSpeed = 0.5f;
        //    _obstacleRotationSpeed = 0.5f;
        //}
    }
}
