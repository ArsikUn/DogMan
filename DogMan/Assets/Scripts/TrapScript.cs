using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public static Action death = delegate { };
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag=="player")
        {
            death();
        }
        
    }
}
