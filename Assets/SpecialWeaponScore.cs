using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialWeaponScore : MonoBehaviour
{
    public ScoreManager score, sample;
    public Text scoreText;
    public Text sampleText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            score.score += 10;
            sample.sample++;
            scoreText.text = "" + score.score;
            sampleText.text = "" + sample.sample;
        }
    }
}
