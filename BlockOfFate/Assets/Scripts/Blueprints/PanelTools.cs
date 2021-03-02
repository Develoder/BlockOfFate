using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelTools : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private FormBlueprint formBlueprint;
    
    
    public void RuneBlueprints()
    {
        formBlueprint.RunBlueprint();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
