using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int sample;
    public Text scoreText;
    public Text sampleText;
    public Text highscoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            score+=10;
            sample++;
            scoreText.text = "" + score;
            sampleText.text = "" + sample;
        }
    }
}