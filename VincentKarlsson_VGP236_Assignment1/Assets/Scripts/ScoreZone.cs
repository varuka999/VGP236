using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int _pointReward = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            //Debug.Log("Ball scored!");
            UIManager.Instance.UpdateScore(_pointReward);
            Destroy(collision.gameObject);
        }
    }
}
