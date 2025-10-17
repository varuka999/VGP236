using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] protected int _scoreReward = 0;
    protected bool _isCollected = false;

    protected virtual void OnEnable()
    {
        _isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Ball" && _isCollected == false)
        {
            _isCollected = true;
            UIManager.Instance.UpdateScore(_scoreReward);
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
