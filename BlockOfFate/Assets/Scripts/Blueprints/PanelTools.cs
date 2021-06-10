using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Панель инструментов для шаблона
public class PanelTools : MonoBehaviour
{
    // Запускает метод на выполнение всех нод
    public void RuneBlueprints()
    {
        PlayerController.instince.ReturnStartPosition();
        FormBlueprint.instance.RunBlueprint();
    }

    // Перезагрузка уровня
    public void ReloadLevel()
    {
        PlayerController.instince.ReturnStartPosition();
    }

    // Удаление последенго шаблона
    public void DeleteLastBlueprint()
    {
        FormBlueprint.instance.DeletedLastBlueprint();
    }

    // Очистка шаблона
    public void ClearFormBlueprint()
    {
        FormBlueprint.instance.DeletedAllBlueprint();
    }
}
