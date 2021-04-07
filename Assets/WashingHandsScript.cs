using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WashingHandsScript : MonoBehaviour
{
    public GameObject WHCollision;
    void Start()
    {
        WHCollision.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    void Update()
    {
        StartCoroutine(RemoveAfterSeconds(0.2f, WHCollision));
    }
    IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}