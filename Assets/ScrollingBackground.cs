using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject[] background;
    public float moveSpeed;
    Vector2 bg1;
    GameObject temp;
    void Start()
    {
        bg1 = background[1].transform.position;
    }

    void Update()
    {
        background[0].transform.position = Vector2.MoveTowards(background[0].transform.position, new Vector2(0, -100), Time.deltaTime * moveSpeed);
        background[1].transform.position = Vector2.MoveTowards(background[1].transform.position, new Vector2(0, -100), Time.deltaTime * moveSpeed);

        if (background[1].transform.position.y <=0)
        {
            background[0].transform.position = bg1;
            temp = background[0];
            background[0] = background[1];
            background[1] = temp;
        }

    }
}
