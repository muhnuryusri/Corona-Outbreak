using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Joystick joystick;
    public Rigidbody2D rb;
    private float ScreenHeight;

    public GameObject steam;
    public GameObject steamDissapear;
    public static bool WeaponFired = false;
    public GameObject stunAnim;
    public GameObject SpecialWeaponIcon;
    public GameObject UltimateBar;
    public GameObject EnergyBar;
    public GameObject Weapon;
    public GameObject SpecialWeapon;
    public GameObject SpecialWeaponEffect;
    public GameObject Light;
    public GameObject GameOverUI;

    public Button button;
    public int maxHealth = 100;
    public int currentHealth;
    public int maxWeapon = 1000;
    public int currentWeapon;
    public int maxEnergy = 100;
    public int currentEnergy;
    public int maxUlt = 100;
    public int currentUlt;
    public float fillTime1;
    public float fillTime2;

    public static bool GameIsOver = false;
    public bool KeyEnabled;
    protected float Timer1;
    protected float Timer2;

    public Animator cam;
    public GameObject green;
    int counter = 0;

    Vector2 movement;

    public HealthBar healthBar;
    public WeaponBar weaponBar;
    public EnergyBar energyBar;
    public UltimateBar ultimateBar;
    
    void Start()
    {
        ScreenHeight = Screen.height;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        KeyEnabled = true;
        steam.SetActive(false);
        steamDissapear.SetActive(false);
        SpecialWeapon.SetActive(false);
        SpecialWeaponEffect.SetActive(false);
        GameOverUI.SetActive(false);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentWeapon = maxWeapon;
        weaponBar.SetMaxWeapon(maxWeapon);

        currentEnergy = 0;
        energyBar.SetMaxEnergy(maxEnergy);
        
        if (currentEnergy == 0)
        {
            energyBar.SetEnergy(currentEnergy);
        }

        currentUlt = 0;
        ultimateBar.SetMaxUltimate(maxUlt);

        green.SetActive(false);
        SpecialWeaponIcon.SetActive(false);
    }

    void Update()
    {
        movement.x = joystick.Horizontal * moveSpeed;
        movement.y = joystick.Vertical * moveSpeed;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }

        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }

        if (WeaponFired == true)
        {
            WeaponDecrease(2);
        }

        if (currentWeapon <= 0)
        {
            currentWeapon = 0;
            if (currentWeapon == 0)
            {
                steamDissapear.SetActive(true);
                steam.SetActive(false);
            }
        }

        if (currentWeapon >= 1000)
        {
            currentWeapon = 1000;
        }

        Timer1 += Time.deltaTime;
        if (Timer1 >= fillTime1)
        {
            Timer1 = 0f;
            currentEnergy++;
            energyBar.SetEnergy(currentEnergy);
        }

        if (currentEnergy >= 100)
        {
            currentEnergy = 100;
            SpecialWeaponIcon.SetActive(true);
        }

        if (currentEnergy <= 0)
        {
            Timer2 += Time.deltaTime;
            if (Timer2 >= fillTime2)
            {
                Timer2 = 0f;
                currentUlt--;
                ultimateBar.SetUltimate(currentUlt);
            }
        }

        if (currentUlt <= 0)
        {
            UltimateBar.SetActive(false);
            EnergyBar.SetActive(true);
            Weapon.SetActive(true);
            SpecialWeapon.SetActive(false);
            SpecialWeaponEffect.SetActive(false);
            Light.SetActive(true);
            KeyEnabled = true;
            currentUlt = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            cam.SetBool("isShake", true);
            FindObjectOfType<SoundManager>().Play("PlayerHit");
            green.SetActive(true);
            Invoke("destroyGreen", 0.1f);
            Invoke("noShake", 0.2f);

            collision.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            TakeDamage(20);
        }

        if (collision.gameObject.tag == "medicine")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            FindObjectOfType<SoundManager>().Play("PickupMedicine");
            Heal(20);
        }

        if (collision.gameObject.tag == "liquid")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            FindObjectOfType<SoundManager>().Play("PickupLiquid");
            Refill(200);
        }
    }

    public void OnPointerDown()
    {
        WeaponFired = true;
        if (KeyEnabled && currentUlt <= 100)
        {
            if (counter == 0 && currentWeapon > 0)
            {
                steamDissapear.SetActive(false);
                steam.SetActive(true);
                counter++;
            }
        }
    }

    public void OnPointerUp()
    {
        WeaponFired = false;
        steam.SetActive(false);
        steamDissapear.SetActive(true);
        counter = 0;
    }

    public void OnButtonPress()
    {
        UltimateBar.SetActive(true);
        EnergyBar.SetActive(false);
        Weapon.SetActive(false);
        steam.SetActive(false);
        steamDissapear.SetActive(false);
        SpecialWeapon.SetActive(true);
        SpecialWeaponEffect.SetActive(true);
        Light.SetActive(false);
        KeyEnabled = false;

        currentUlt = 100;
        currentEnergy = -30;

        button.gameObject.SetActive(false);
    }

    void destroyGreen()
    {
        green.SetActive(false);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void WeaponDecrease(int steam)
    {
        currentWeapon -= steam;

        weaponBar.SetWeapon(currentWeapon);
    }

    public void Stun(float timeStun)
    {
        moveSpeed = 0f;
        stunAnim.SetActive(true);
        Invoke("RecoverStun", timeStun);
        FindObjectOfType<SoundManager>().Play("Stun");
        cam.SetBool("isShake", true);
        Invoke("noShake", 0.2f);
    }

    void RecoverStun()
    {
        moveSpeed = 2f;
        stunAnim.SetActive(false);
    }

    void Heal(int healing)
    {
        currentHealth += healing;

        healthBar.SetHealth(currentHealth);
    }

    void Refill(int refill)
    {
        currentWeapon += refill;

        weaponBar.SetWeapon(currentWeapon);
    }

    void noShake()
    {
        cam.SetBool("isShake", false);
    }

    void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
        AudioListener.pause = true;
    }
}
