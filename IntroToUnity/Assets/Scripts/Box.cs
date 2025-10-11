using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxDistanceFromtStart = 8.0f;

    private Vector3 startPosition = Vector2.zero;
    //private Vector2 position = Vector2.zero;

    private void Awake()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
            position.x = -moveSpeed * Time.deltaTime;
            //transform.position = position;
            Debug.Log(position.x);
            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            //position.x = moveSpeed * Time.deltaTime;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
