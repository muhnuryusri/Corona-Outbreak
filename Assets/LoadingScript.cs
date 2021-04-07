using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public Image LoadingFill;
    public float timeLeft;
    void Start()
    {
        LoadingFill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LoadingFill.fillAmount += 1 / timeLeft * Time.deltaTime;

        if (LoadingFill.fillAmount == 1)
        {
            LoadingFill.fillAmount = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
