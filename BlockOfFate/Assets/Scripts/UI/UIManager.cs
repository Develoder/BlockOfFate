using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ExitGame()
    {
        GameSceneManager.instance.ExitGame();
    }

    public void MainMenu()
    {
        GameSceneManager.instance.LoadMainMenu();
    }
}
