using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportText2 : MonoBehaviour
{
    public GameObject Text2;
    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(RemoveAfterSeconds(5, Text2));
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
