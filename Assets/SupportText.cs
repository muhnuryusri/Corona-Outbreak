using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportText : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(RemoveAfterSeconds(5, Text1));
        StartCoroutine(RemoveAfterSeconds(5, Text2));
        StartCoroutine(RemoveAfterSeconds(5, Text3));
        if (Text1.activeSelf == true)
        {
            Text2.SetActive(false);
            Text3.SetActive(false);
        }

        if (Text2.activeSelf == true)
        {
            Text1.SetActive(false);
            Text3.SetActive(false);
        }

        if (Text3.activeSelf == true)
        {
            Text1.SetActive(false);
            Text2.SetActive(false);
        }
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
