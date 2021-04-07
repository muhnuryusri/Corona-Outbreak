using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject transition;

    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        transition.SetActive(true);
    }
    public void PlayGame()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().Play("ButtonClick");
        Application.Quit();
    }
    void Update()
    {
        StartCoroutine(RemoveAfterSeconds(2f, transition));
    }
    IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}