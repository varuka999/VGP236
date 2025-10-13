using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2.5f;
    [SerializeField] private float _maxDistanceFromOrigin = 0.0f; 

    private void Update()
    {
        //OrbitMove();
        Move();
    }

    private void OrbitMove()
    {
        Vector3 position = this.transform.position;
        position.x -= 0.3f * Time.deltaTime;

        this.transform.position = position;
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
