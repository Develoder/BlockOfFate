using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject[] starOff;
    [SerializeField] private GameObject[] starOn;
    [SerializeField] private GameObject maskPlane;

    private int currenLevel;
    private bool isActive;
    
    public void Init(int level, int star, bool isActive)
    {
        currenLevel = level;
        this.isActive = isActive;
        
        SetLevel(level);
        ActiveStars(star);
        ButtonEnable(isActive);
    }

    private void SetLevel(int level)
    {
        levelText.text = level.ToString();
    }

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

    private void ButtonEnable(bool isActive)
    {
        if (isActive)
            maskPlane.SetActive(false);
        else
            maskPlane.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isActive)
        {
            MainMenu.instance.SaveCurrentLevel(currenLevel);
            GameSceneManager.instance.LoadLevel(currenLevel);
        }
    }
}
