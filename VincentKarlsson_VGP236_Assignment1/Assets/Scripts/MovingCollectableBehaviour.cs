using UnityEngine;

public class MovingCollectableBehaviour : CollectableBehaviour
{
    [SerializeField] private GameObject _explosionRadius = null;
    [SerializeField] private float _moveSpeed = 4.0f;

    private void OnEnable()
    {
        _moveSpeed = Mathf.Abs(_moveSpeed) * this.gameObject.transform.localScale.z;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 position = this.transform.position;
        position.x += _moveSpeed * Time.deltaTime;

        this.transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Ball" && _isCollected == false)
            {
                _isCollected = true;
                _explosionRadius.transform.position = this.transform.position;
                _explosionRadius.SetActive(true);

                UIManager.Instance.UpdateScore(_scoreReward);
                Destroy(collision.gameObject);
                this.gameObject.SetActive(false);
            }
            else if (collision.tag == "Destroy Zone")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
