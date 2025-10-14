using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ballRigidBody2D = null;
    [SerializeField] private float _baseGravityScale = 0.0f;
    [SerializeField] private float _gravityRate = 0.1f;
    private float _timer = 0.0f;

    private void Awake()
    {
        if (_ballRigidBody2D == null)
        {
            _ballRigidBody2D = GetComponent<Rigidbody2D>();
        }

        _ballRigidBody2D.gravityScale = _baseGravityScale;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        UpdateGravity();
    }

    private void UpdateGravity()
    {
        _ballRigidBody2D.gravityScale = _baseGravityScale + (_timer * _gravityRate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Gravity Shift")
            {
                _gravityRate = 1f;
            }
            else if (collision.tag == "Destroy Zone")
            {
                DestroySelf();
            }
        }
    }

    public void DestroySelf()
    {
        if (this.gameObject != null && this.gameObject.activeSelf == true)
        {
            Destroy(this.gameObject);
        }
    }

}
