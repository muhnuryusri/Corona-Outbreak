using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineScript : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {

    }

    void Update()
    {
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -100), Time.deltaTime * moveSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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