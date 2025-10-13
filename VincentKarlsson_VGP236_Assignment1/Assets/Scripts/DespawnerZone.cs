using UnityEngine;

public class DespawnerZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
