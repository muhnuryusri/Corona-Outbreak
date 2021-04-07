using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialDistancingScript : MonoBehaviour
{
    public GameObject SDCollision;
    void Start()
    {
        SDCollision.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(RemoveAfterSeconds(0.8f, SDCollision));
    }
    IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
