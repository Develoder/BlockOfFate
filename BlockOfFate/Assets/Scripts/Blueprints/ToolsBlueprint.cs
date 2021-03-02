using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolsBlueprint : MonoBehaviour, IPointerClickHandler
{
    [Header("Scene")]
    [SerializeField] private ConnectorToolsBueprint conToolsBueprint;
    
    [Header("Parameters")]
    [SerializeField] private BlueprintBase.TypeBlueprint typeBlueprint;


    public void OnPointerClick(PointerEventData eventData)
    {
        conToolsBueprint.ClickedTool(typeBlueprint);
    }
}
