using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevl : MonoBehaviour
{
   
    private bool _win;

    void Start()
    {
        UIManager.win += UIManager_Win;
    }

    private void UIManager_Win()
    {
        _win = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (_win)
        {
            SceneSwith.SwithToScene(3);
            
        }
       
    }

    void OnDisable()
    {
        UIManager.win -= UIManager_Win;
    }
}
