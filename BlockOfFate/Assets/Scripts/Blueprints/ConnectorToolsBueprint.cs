using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorToolsBueprint : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private FormBlueprint formBlueprint;


    public void ClickedTool(BlueprintBase.TypeBlueprint typeBlueprint)
    {
        formBlueprint.AppendBlueprint(typeBlueprint);
    }
}
