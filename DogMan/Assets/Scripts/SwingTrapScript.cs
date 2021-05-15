using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTrapScript : MonoBehaviour
{
    private Animation swingAnimation;
    void Start()
    {
        swingAnimation = GetComponent<Animation>();
        swingAnimation.Play();
    }

}
