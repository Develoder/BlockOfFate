using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelTools : MonoBehaviour
{
    public void RuneBlueprints()
    {
        PlayerController.instince.ReturnStartPosition();
        FormBlueprint.instance.RunBlueprint();
    }

    public void ReloadLevel()
    {
        PlayerController.instince.ReturnStartPosition();
    }

    public void DeleteLastBlueprint()
    {
        FormBlueprint.instance.DeletedLastBlueprint();
    }

    public void ClearFormBlueprint()
    {
        FormBlueprint.instance.DeletedAllBlueprint();
    }
}
