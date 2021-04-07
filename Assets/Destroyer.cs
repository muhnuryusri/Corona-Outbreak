using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Start()
    {
        Invoke("destroy", 1f);
    }

    // Update is called once per frame
    public void destroy()
    {
        Destroy(gameObject);
    }
}
