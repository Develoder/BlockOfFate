using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс финиша
public class Finish : MonoBehaviour
{
    // Метод проверки зашел ли игрок на текущую клетку
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Finished();
        }
    }

    // Выполнение финиша с последующим сохранением
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
