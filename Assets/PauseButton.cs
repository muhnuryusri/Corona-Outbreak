using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        Pause();
    }

    public void ResumeGame()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        Resume();
    }

    public void MainMenu()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
        AudioListener.pause = false;
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        Application.Quit();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }


}
