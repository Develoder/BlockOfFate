using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.Linq;

// Калсс сохранения шаблонов в базу данных
public class DatabaseBlueprint : MonoBehaviour
{
    public static DatabaseBlueprint instance;

    // Словарь соответствий символов и типа ноды
    private static Dictionary<string, BlueprintBase.TypeBlueprint> complineCharBlpr = new Dictionary<string, BlueprintBase.TypeBlueprint>()
    {
        {"1", BlueprintBase.TypeBlueprint.Left},
        {"2", BlueprintBase.TypeBlueprint.Right},
        {"3", BlueprintBase.TypeBlueprint.Forward},
        {"4", BlueprintBase.TypeBlueprint.Back}
    };

    private int currentLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadBlueprint();
        GameSceneManager.instance.ChangeSceneEvent += SaveBlueprint;
    }

    // Загрузка сохраненных нод
    private void LoadBlueprint()
    {
        currentLevel = MainMenu.instance.GetCurrentLevel();

        DataTable idBlueprint = MyDataBase.GetTable("SELECT id_conroller FROM level_controller " +
                                                    $"WHERE id_level = {currentLevel}");
        
        foreach (DataRow row in idBlueprint.Rows)
        {
            FormBlueprint.instance.AppendBlueprint(complineCharBlpr[row[0].ToString()]);
        }
    }

    // Сохраняет шаблон текущего уровня
    private void SaveBlueprint()
    {
        List<string> saveChar = new List<string>();

        foreach (BlueprintBase blueprint in FormBlueprint.instance.blueprintBases)
        {
            saveChar.Add(complineCharBlpr.FirstOrDefault(x => x.Value == blueprint.typeBlueprint).Key);
        }
        
        MyDataBase.ExecuteQueryWithoutAnswer($"DELETE FROM level_controller WHERE id_level = {currentLevel}");

        foreach (string s in saveChar)
        {
            MyDataBase.ExecuteQueryWithoutAnswer("INSERT INTO level_controller (id_conroller, id_level)" +
                                                 $" VALUES ({s}, {currentLevel})");
        }
    }
}
