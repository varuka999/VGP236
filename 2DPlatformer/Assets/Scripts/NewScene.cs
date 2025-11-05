using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    private int player1Contact = 0;
    private int player2Contact = 0;
    [SerializeField] private string nextSceneName = string.Empty;

    public bool IsBothPlayersReady { get { return player1Contact > 0 && player2Contact > 0; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            ++player1Contact;
        }
        if (collision.tag == "Player2")
        {
            ++player2Contact;
        }

        if (IsBothPlayersReady == true)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
