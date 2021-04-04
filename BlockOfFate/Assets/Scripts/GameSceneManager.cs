using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    
    public event Action ChangeSceneEvent;

    private void Awake()
    {
        instance = this;
    }

    public void LoadScene(string name)
    {
        ChangeScene(name);
    }

    public void LoadLevel(int level)
    {
        ChangeScene($"Level_{level}");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        ChangeScene("Menu");
    }

    private void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        
        if (ChangeSceneEvent != null)
            ChangeSceneEvent();
    }
}
