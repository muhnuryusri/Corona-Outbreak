using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevScene : MonoBehaviour
{

    public void PlayGame()
    {

    }


    void Update()
    {
        StartCoroutine(LoadAfterSeconds(8f));
    }
    IEnumerator LoadAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
