using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _obstacleRigidBody2D = null;

    //private float _obstacleXScale = 0.0f;
    //private float _obstacleYScale = 0.0f;
    //private float _obstacleMass = 0.0f;
    private float _obstacleMoveSpeed = 0.9f;
    private float _obstacleRotationSpeed = 0.0f;

    private void Update()
    {
        Move();
    }

    public void Initialize(float minX, float maxX, float minY, float maxY, float minRotate, float maxRotate, float moveSpeed)
    {
        if (_obstacleRigidBody2D != null)
        {
            float obstacleXScale = Random.Range(minX, maxX);
            float obstacleYScale = Random.Range(minY, maxY);
            float obstacleMass = (obstacleXScale * obstacleYScale) * 100;
            _obstacleMoveSpeed = moveSpeed;
            _obstacleRotationSpeed = Random.Range(minRotate, maxRotate);

            Vector3 newScale = new Vector3(obstacleXScale, obstacleYScale, 0.0f);
            this.gameObject.transform.localScale = newScale;
            _obstacleRigidBody2D.mass = obstacleMass;
        }
    }

    private void Move()
    {
        Vector3 position = this.transform.position;
        position.x -= _obstacleMoveSpeed * Time.deltaTime;

        Vector3 rotation = new Vector3(0, 0, _obstacleRotationSpeed);

        this.transform.position = position;
        this.transform.Rotate(rotation * Time.deltaTime);
    }
}
