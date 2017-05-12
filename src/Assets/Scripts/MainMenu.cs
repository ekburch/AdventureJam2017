using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        var sceneManager = GameObject.FindObjectOfType<ScenesManager>();

        if (sceneManager != null)
            sceneManager.GoToCityScene();
    }
}
