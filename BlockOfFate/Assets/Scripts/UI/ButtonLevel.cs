using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Класс кнопки выбора уровня
public class ButtonLevel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject[] starOff;
    [SerializeField] private GameObject[] starOn;
    [SerializeField] private GameObject maskPlane;

    private int currenLevel;
    private bool isActive;
    
    // Инициализация кнопки уровня (не конструктор)
    public void Init(int level, int star, bool isActive)
    {
        currenLevel = level;
        this.isActive = isActive;
        
        SetLevel(level);
        ActiveStars(star);
        ButtonEnable(isActive);
    }

    // Установка названия уровня
    private void SetLevel(int level)
    {
        levelText.text = level.ToString();
    }

    // Активация или деактивация кнопки в соответсвии пройденным уровням
    private void ActiveStars(int count)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < count)
            {
                starOn[i].SetActive(true);
                starOff[i].SetActive(false);
            }
            else
            {
                starOn[i].SetActive(false);
                starOff[i].SetActive(true);
            }
        }
    }

    // Деактивация кнопки
    private void ButtonEnable(bool isActive)
    {
        if (isActive)
            maskPlane.SetActive(false);
        else
            maskPlane.SetActive(true);
    }

    // Нажатие кнопки и последующая загрузка уровня
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isActive)
        {
            MainMenu.instance.SaveCurrentLevel(currenLevel);
            GameSceneManager.instance.LoadLevel(currenLevel);
        }
    }
}
