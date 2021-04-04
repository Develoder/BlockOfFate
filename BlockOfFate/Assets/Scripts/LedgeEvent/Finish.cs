using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Finished();
        }
    }

    private void Finished()
    {
        int currentLevel = MainMenu.instance.GetCurrentLevel();
        if (currentLevel == -1)
        {
            GameSceneManager.instance.LoadMainMenu();
            return;
        }
        
        MainMenu.instance.SetStarsLevel(3);
        
        GameSceneManager.instance.LoadMainMenu();
    }
}
