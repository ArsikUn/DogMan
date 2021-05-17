using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Reload()
    {
        audioSource.Play();
        var activeScene = SceneManager.GetActiveScene();
        SceneSwith.SwithToScene(activeScene.buildIndex);
    }

    public void LoadLevl(int LevlIndex)
    {
        audioSource.Play();
        SceneSwith.SwithToScene(LevlIndex);
    }
}
