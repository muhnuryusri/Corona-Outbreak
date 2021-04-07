using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl2 : MonoBehaviour
{
    public float moveSpeed;
    GameObject target;
    public GameObject efx;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (transform.position.y <= target.transform.position.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -100), moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
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