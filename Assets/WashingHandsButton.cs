using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WashingHandsButton : MonoBehaviour
{
    public Image CooldownImage;
    public GameObject Button;
    public GameObject CDButton;
    public GameObject WHCollision;
    public Text Text;
    public float timeLeft = 20;
    public bool Cooldown = false;

    void Start()
    {
        CDButton.SetActive(false);
        CooldownImage.fillAmount = 0;
    }

    public void OnButtonPress()
    {
        CDButton.SetActive(true);
        Cooldown = true;
        CooldownImage.fillAmount = 1;
        WHCollision.SetActive(true);
        Text.gameObject.SetActive(true);
        FindObjectOfType<SoundManager>().Play("SupportClick");
    }

    void Update()
    {
        if (Cooldown)
        {
            CooldownImage.fillAmount -= 1 / timeLeft * Time.deltaTime;

            if (CooldownImage.fillAmount <= 0)
            {
                CooldownImage.fillAmount = 0;
                CDButton.SetActive(false);
                Cooldown = false;
            }
        }
    }
}