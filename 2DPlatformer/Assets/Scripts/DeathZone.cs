using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private string _thisSceneName = string.Empty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            SceneManager.LoadScene(_thisSceneName);
        }
    }
}
