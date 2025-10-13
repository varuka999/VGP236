using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2.5f;

    private void Start()
    {

    }

    private void Update()
    {
        OrbitMove();
        Move();
    }

    private void OrbitMove()
    {
        Vector3 position = transform.position;
        position.x -= 0.3f * Time.deltaTime;

        transform.position = position;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = transform.position;

            position.x -= _movementSpeed * Time.deltaTime;

            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = transform.position;

            position.x += _movementSpeed * Time.deltaTime;

            transform.position = position;
        }
    }
}
