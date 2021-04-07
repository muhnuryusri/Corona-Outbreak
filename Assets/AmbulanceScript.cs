using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceScript : MonoBehaviour
{
    public float moveSpeed;
    PlayerMovement player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -100), Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScreenCollider")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
            FindObjectOfType<SoundManager>().Play("AmbulanceHit");
            FindObjectOfType<SoundManager>().Play("AmbulanceCrash");
            player.Stun(2);
        }

        if (collision.gameObject.tag == "enemy")
        {
            GameObject.FindGameObjectWithTag("enemy").transform.position = transform.position;
        }
    }

}
