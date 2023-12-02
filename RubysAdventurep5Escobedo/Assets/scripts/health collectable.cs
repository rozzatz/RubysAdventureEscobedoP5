using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectable : MonoBehaviour
{
    public AudioClip collectedCip;
     void OnTriggerEnter2D(Collider2D other)
    {
        rubycontroller controller  = other.GetComponent<rubycontroller>();
        if (controller != null )
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);

                controller.Playsound(collectedCip);
            }
        }
        
    }
}
