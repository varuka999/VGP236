using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" !)
        {
            this.gameObject.SetActive(false);
        }
    }
}
