using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskerSupportScript : MonoBehaviour
{
    public GameObject Barrier;
    void Start()
    {
        Barrier.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }

        if (collision.gameObject.tag == "ambulance")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void Update()
    {
        StartCoroutine(RemoveAfterSeconds(5, Barrier));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
