using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    ScoreManager highscoreText;
    void Start()
    {
        AudioListener.pause = false;
    }
    public void Restart()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        RestartGame();
    }

    public void Exit()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        ExitGame();
    }
    void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    void ExitGame()
    {
        SceneManager.LoadScene("Start Menu");
    }
}