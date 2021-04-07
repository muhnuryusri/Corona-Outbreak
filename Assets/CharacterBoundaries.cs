using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundaries : MonoBehaviour
{
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.36f, 2.02f),
            Mathf.Clamp(transform.position.y, -4.95f, 4.20f), transform.position.z);
    }
}
