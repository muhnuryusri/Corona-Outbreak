using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundaries2 : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.30f, 1.76f),
            Mathf.Clamp(transform.position.y, -5.2f, 4.2f), transform.position.z);
    }
}
