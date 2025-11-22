using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneButtons : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
