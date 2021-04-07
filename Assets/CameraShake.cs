using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
    public Animator CamAnimation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            CamAnimation.SetBool("isShake", true);
            Invoke("noShake", 0.2f);
        }
    }
    
    void noShake()
    {
        CamAnimation.SetBool("isShake", false);
    }
}
