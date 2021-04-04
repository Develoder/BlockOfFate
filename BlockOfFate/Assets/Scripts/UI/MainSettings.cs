using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;

public class MainSettings : MonoBehaviour
{
    [SerializeField] private Toggle music;
    [SerializeField] private Toggle sound;

    private bool isMusic;
    private bool isSound;

    private bool isLoad;
    
    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        isMusic = MainMenu.instance.GetMusic();
        isSound = MainMenu.instance.GetSound();
        SetToggles();
        isLoad = true;
    }

    private void SetToggles()
    {
        music.isOn = isMusic;
        sound.isOn = isSound;
    }

    public void ChangeMusic(bool isMusic)
    {
        if (!isLoad) 
            return;
        
        this.isMusic = music.isOn;
        SaveMusic();
    }
    
    public void ChangeSound(bool isSound)
    {
        if (!isLoad) 
            return;
        
        this.isSound = sound.isOn;
        SaveSound();
    }

    private void SaveMusic()
    {
        MainMenu.instance.SaveMusic(isMusic);
    }

    private void SaveSound()
    {
        MainMenu.instance.SaveSound(isSound);
    }

    private void SaveSettings()
    {
        SaveSound();
        SaveMusic();
    }
}
