using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject _correspondingPath = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            _correspondingPath.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
