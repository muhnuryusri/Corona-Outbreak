using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl3 : MonoBehaviour
{
    public float moveSpeed;
    GameObject target;
    public GameObject efx;
    int health = 3;
    void Start()
    {

    }

    void Update()
    {
        if (health <= 0)
        {
            Instantiate(efx, transform.position, Quaternion.identity);
            FindObjectOfType<SoundManager>().Play("EnemyHit");
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -100), Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "steam")
        {
            health--;
        }

        if (collision.gameObject.tag == "WHCollision")
        {
            Instantiate(efx, transform.position, Quaternion.identity);
            FindObjectOfType<SoundManager>().Play("EnemyHit");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "ScreenCollider")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}