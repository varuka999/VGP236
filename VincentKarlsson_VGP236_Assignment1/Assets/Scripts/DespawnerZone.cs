using UnityEngine;

public class DespawnerZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Ball destroyed!");
            Destroy(collision.gameObject);
        }
    }
}
