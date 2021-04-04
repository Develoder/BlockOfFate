using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    [SerializeField] private Button startCurrentLevel;

    private int user = 1;
    
    private void Awake()
    {
        instance = this;
    }

    public int GetCurrentLevel()
    {
        string curLevel = MyDataBase.ExecuteQueryWithAnswer($"SELECT last_level FROM Setting WHERE id_setting = {user}");
        if (curLevel == "")
            return -1;
        return Convert.ToInt32(curLevel);
    }

    public void SaveCurrentLevel(int level)
    {
        MyDataBase.ExecuteQueryWithoutAnswer($"UPDATE Setting SET last_level = {level} WHERE id_setting = {user}");
    }
    
    public bool GetMusic()
    {
        string curMusic = MyDataBase.ExecuteQueryWithAnswer($"SELECT music FROM Setting WHERE id_setting = {user}");
        return curMusic == "1";
    }
    
    
    public bool GetSound()
    {
        string curSound = MyDataBase.ExecuteQueryWithAnswer($"SELECT effect FROM Setting WHERE id_setting = {user}");
        return curSound == "1";
    }

    public void SaveMusic(bool isActive)
    {
        int save = isActive ? 1 : 0;
        MyDataBase.ExecuteQueryWithoutAnswer($"UPDATE Setting SET music = '{save}' WHERE id_setting = {user}");
    }

    public void SaveSound(bool isActive)
    {
        int save = isActive ? 1 : 0;
        MyDataBase.ExecuteQueryWithoutAnswer($"UPDATE Setting SET effect = '{save}' WHERE id_setting = {user}");
    }

    public void SetStarsLevel(int count)
    {
        int currentLevel = GetCurrentLevel();
        
        MyDataBase.ExecuteQueryWithoutAnswer($"UPDATE Level SET countStars = {count} WHERE id_level = {currentLevel};");
        MyDataBase.ExecuteQueryWithoutAnswer($"UPDATE Level SET completed = '1' WHERE id_level = {currentLevel};");
    }
}
