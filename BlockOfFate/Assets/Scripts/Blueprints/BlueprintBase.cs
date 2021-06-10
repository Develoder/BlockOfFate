using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Класс базовой ноды
public class BlueprintBase : MonoBehaviour
{
    [SerializeField] private Text textName;

    // Тип ноды
    public enum TypeBlueprint
    {
        Left,
        Right,
        Forward,
        Back
    }

    private TypeBlueprint _typeBlueprint;

    public TypeBlueprint typeBlueprint
    {
        set
        {
            _typeBlueprint = value;
            ChangeType(value);
        }
        get { return _typeBlueprint; }
    }

    // Проигрывание ноды
    public void RunBlueprint()
    {
        switch (_typeBlueprint)
        {
            case TypeBlueprint.Left:
                PlayerController.instince.MovePlayer(-1, 0);
                break;
            case TypeBlueprint.Right:
                PlayerController.instince.MovePlayer(1, 0);
                break;
            case TypeBlueprint.Forward:
                PlayerController.instince.MovePlayer(0, 1);
                break;
            case TypeBlueprint.Back:
                PlayerController.instince.MovePlayer(0, -1);
                break;

            default:
                Debug.LogWarning($"The blueprint is not set for the {gameObject.name}");
                break;
        }
    }

    // Смета типа ноды
    private void ChangeType(TypeBlueprint blueprint)
    {
        switch (blueprint)
        {
            case TypeBlueprint.Left:
                textName.text = "Left";
                break;
            case TypeBlueprint.Right:
                textName.text = "Right";
                break;
            case TypeBlueprint.Forward:
                textName.text = "Forward";
                break;
            case TypeBlueprint.Back:
                textName.text = "Back";
                break;
        }
    }
}