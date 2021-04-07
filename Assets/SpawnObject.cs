using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public ScoreManager score;

    public GameObject[] corona1, corona2, corona3, medicine, liquid, ambulance1;
    float random;
    float random2;

    float corona1Time;
    float corona1Timer = 2;

    float corona2Time;
    float corona2Timer = 3;

    float corona3Time;
    float corona3Timer;

    float medicineTime;
    float medicineTimer;

    float liquidTime;
    float liquidTimer;

    float ambulance1Time;
    float ambulance1Timer;

    void Start()
    {
        liquidTimer = Random.Range(5, 10);
        medicineTimer = Random.Range(10, 15);
        ambulance1Timer = Random.Range(15, 20);
        corona3Timer = Random.Range(10, 15);
    }

    void Update()
    {
        random = Random.Range(-2.3f, 2.2f);
        random2 = Random.Range(-2.95f, 3.10f);

        if (score.score >= 50)
        {
            if (corona1Time <= 0)
            {
                Instantiate(corona1[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona1Timer = 1;
                corona1Time = corona1Timer;
            }
            else
            {
                corona1Time -= Time.deltaTime;
            }

            if (corona2Time <= 0)
            {
                Instantiate(corona2[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona2Timer = 2;
                corona2Time = corona2Timer;
            }
            else
            {
                corona2Time -= Time.deltaTime;
            }

            if (corona3Time <= 0)
            {
                Instantiate(corona3[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona3Time = corona3Timer;
                corona3Timer = Random.Range(15, 40);
            }
            else
            {
                corona3Time -= Time.deltaTime;
            }
        }
        else if (score.score >= 20)
        {
            if (corona1Time <= 0)
            {
                Instantiate(corona1[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona1Time = corona1Timer;
            }
            else
            {
                corona1Time -= Time.deltaTime;
            }

            if (corona2Time <= 0)
            {
                Instantiate(corona2[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona2Time = corona2Timer;
            }
            else
            {
                corona2Time -= Time.deltaTime;
            }

            if (corona3Time <= 0)
            {
                Instantiate(corona3[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona3Time = corona3Timer;
                corona3Timer = Random.Range(15, 40);
            }
            else
            {
                corona3Time -= Time.deltaTime;
            }
        }
        else if (score.score >= 10)
        {
            if (corona1Time <= 0)
            {
                Instantiate(corona1[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona1Time = corona1Timer;
            }
            else
            {
                corona1Time -= Time.deltaTime;
            }

            if (corona2Time <= 0)
            {
                Instantiate(corona2[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona2Time = corona2Timer;
            }
            else
            {
                corona2Time -= Time.deltaTime;
            }
        }
        else if (score.score >= 5)
        {
            if (corona2Time <= 0)
            {
                Instantiate(corona2[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona2Time = corona2Timer;
            }
            else
            {
                corona2Time -= Time.deltaTime;
            }
        }
        else
        {
            if (corona1Time <= 0)
            {
                Instantiate(corona1[0], new Vector2(random, transform.position.y), Quaternion.identity);
                corona1Time = corona1Timer;
            }
            else
            {
                corona1Time -= Time.deltaTime;
            }
        }


        if (medicineTime <= 0)
        {
            Instantiate(medicine[0], new Vector2(random, transform.position.y), Quaternion.identity);
            medicineTime = medicineTimer;
            medicineTimer = Random.Range(10, 15);
        }
        else
        {
            medicineTime -= Time.deltaTime;
        }

        if (liquidTime <= 0)
        {
            Instantiate(liquid[0], new Vector2(random, transform.position.y), Quaternion.identity);
            liquidTime = liquidTimer;
            liquidTimer = Random.Range(5, 10);
        }
        else
        {
            liquidTime -= Time.deltaTime;
        }

        if (ambulance1Time <= 0)
        {
            Instantiate(ambulance1[0], new Vector2(random2, transform.position.y), Quaternion.identity);
            ambulance1Time = ambulance1Timer;
            ambulance1Timer = Random.Range(15, 20);
        }
        else
        {
            ambulance1Time -= Time.deltaTime;
        }
    }
}