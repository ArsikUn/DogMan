using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Reload()
    {
        var activeScene = SceneManager.GetActiveScene();
        SceneSwith.SwithToScene(activeScene.buildIndex);
    }

    public void LoadLevl(int LevlIndex)
    {
        SceneSwith.SwithToScene(LevlIndex);
    }
}
