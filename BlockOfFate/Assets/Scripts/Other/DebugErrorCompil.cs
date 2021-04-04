using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugErrorCompil : MonoBehaviour
{
    [SerializeField] private Text textDebug;
    
    void OnEnable()
    {
        Application.logMessageReceived += LogCallback;
    }


    void LogCallback(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Log) 
            return;
        textDebug.text += $"{type}, {condition}\n\n";
    }
}
