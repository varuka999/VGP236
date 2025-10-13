using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Ball scored!");
            Destroy(collision.gameObject);
        }
    }
}
