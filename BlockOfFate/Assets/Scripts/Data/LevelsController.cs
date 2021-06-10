using System;
using System.Data;
using UnityEngine;

// Управление уровнем
public class LevelsController : MonoBehaviour
{
    [SerializeField] private GameObject prefabButtonLevel;

    private void Start()
    {
        GenerateLevelButton();
    }

    // Генерирует шаблон по сохраненным данным из БД
    private void GenerateLevelButton()
    {
        DataTable dataTable = MyDataBase.GetTable("SELECT * FROM Level");
        int level;
        int countStars;
        bool isCompleted;
        GameObject game;
        ButtonLevel buttonLevel;

        int countOpenNextLevel = 3;
        
        foreach (DataRow row in dataTable.Rows)
        {
            level = Convert.ToInt32(row[0]);
            countStars = Convert.ToInt32(row[3]);
            isCompleted = Convert.ToBoolean(row[2]);
            if (!isCompleted)
                if (countOpenNextLevel > 0)
                {
                    isCompleted = true;
                    countOpenNextLevel--;
                }
            
            game = Instantiate(prefabButtonLevel, transform);
            buttonLevel = game.GetComponent<ButtonLevel>();
            buttonLevel.Init(level, countStars, isCompleted);
        }
    }
}
