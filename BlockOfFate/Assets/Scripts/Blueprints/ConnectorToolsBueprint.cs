using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorToolsBueprint : MonoBehaviour
{
    public static ConnectorToolsBueprint instance;
    
    private void Awake()
    {
        instance = this;
    }

    public void ClickedTool(BlueprintBase.TypeBlueprint typeBlueprint)
    {
        FormBlueprint.instance.AppendBlueprint(typeBlueprint);
    }
}
