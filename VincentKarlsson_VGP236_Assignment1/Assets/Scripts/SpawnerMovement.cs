using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2.5f;
    [SerializeField] private float _maxDistanceFromOrigin = 0.0f;
    [SerializeField] private bool _isOrbitActive = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isOrbitActive = !_isOrbitActive;
        }

        OrbitMove();
        Move();
    }

    private void OrbitMove()
    {
        if (_isOrbitActive)
        {
            Vector3 position = this.transform.position;
            position.x -= 0.3f * Time.deltaTime;

            this.transform.position = position;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;

            position.x -= _movementSpeed * Time.deltaTime;

            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;

            position.x += _movementSpeed * Time.deltaTime;

            this.transform.position = position;
        }

        if (Mathf.Abs(this.transform.position.x) > _maxDistanceFromOrigin)
        {
            if (this.transform.position.x < -_maxDistanceFromOrigin)
            {
                this.transform.position = new Vector3(-_maxDistanceFromOrigin, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x > _maxDistanceFromOrigin)
            {
                this.transform.position = new Vector3(_maxDistanceFromOrigin, this.transform.position.y, this.transform.position.z);
            }
        }
    }
}
