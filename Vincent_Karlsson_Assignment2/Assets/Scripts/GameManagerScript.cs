using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private bool paused = false;

    public string mainScene;

    public GameObject pauseMenu;
    public Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        
        pauseButton.interactable = false;
        Time.timeScale = 0;
        paused = true;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        
        pauseButton.interactable = true;
        Time.timeScale = 1;
        paused = false;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(mainScene);
    }
}
