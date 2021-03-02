using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintBase : MonoBehaviour
{
    [SerializeField] private Text textName;
    
    
    private MoveGrid moveGrid;

    public enum TypeBlueprint
    {
        Left,
        Right,
        Forward,
        Back
    }

    private TypeBlueprint typeBlueprint;

    public TypeBlueprint setTypeBlueprint
    {
        set
        {
            typeBlueprint = value;
            ChangeType(value);
        }
    }

    private void Start()
    {
        moveGrid = GameObject.Find("SM_Prop_Bowling_Pin_01").GetComponent<MoveGrid>();
    }

    public void RunBlueprint()
    {
        switch (typeBlueprint)
        {
            case TypeBlueprint.Left:
                moveGrid.MoveObject(-1, 0);
                break;
            case TypeBlueprint.Right:
                moveGrid.MoveObject(1, 0);
                break;
            case TypeBlueprint.Forward:
                moveGrid.MoveObject(0, 1);
                break;
            case TypeBlueprint.Back:
                moveGrid.MoveObject(0, -1);
                break;

            default:
                Debug.LogWarning($"The blueprint is not set for the {gameObject.name}");
                break;
        }
    }

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