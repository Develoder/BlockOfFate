using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentLevel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject maskImage;
    
    private int currentLevel;
    
    private void Start()
    {
        currentLevel = MainMenu.instance.GetCurrentLevel();
        if (currentLevel == -1)
            maskImage.SetActive(true);
        else
            maskImage.SetActive(false);
    }


    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentLevel == -1)
            return;
        
        GameSceneManager.instance.LoadLevel(currentLevel);
    }
}
