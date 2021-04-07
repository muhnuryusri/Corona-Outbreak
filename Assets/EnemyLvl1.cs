using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl1 : MonoBehaviour
{
    public float moveSpeed;
    public GameObject efx;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -100), Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "steam")
        {
            Instantiate(efx, transform.position, Quaternion.identity);
            FindObjectOfType<SoundManager>().Play("EnemyHit");
            Destroy(gameObject);
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