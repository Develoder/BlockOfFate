using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBlueprint : MonoBehaviour
{
    [Header("Scene")] 
    [SerializeField] private GameObject content;

    [Header("Project")] 
    [SerializeField] private GameObject basePlane;

    [Header("Parameters")] 
    [SerializeField] private float timeSteep = 1f;

    private List<GameObject> gameBlueprints = new List<GameObject>();
    private List<BlueprintBase> blueprintBases = new List<BlueprintBase>();


    public void RunBlueprint()
    {
        StartCoroutine(IERunBlueprint());
    }

    IEnumerator IERunBlueprint()
    {
        foreach (BlueprintBase blprBases in blueprintBases)
        {
            blprBases.RunBlueprint();
            yield return new WaitForSeconds(timeSteep);
        }
    }

    public void AppendBlueprint(BlueprintBase.TypeBlueprint typeBlueprint)
    {
        print($"Blueprint is create {typeBlueprint}");
        GameObject blue = Instantiate(basePlane, content.transform);
        BlueprintBase blueBase = blue.GetComponent<BlueprintBase>();
        blueBase.setTypeBlueprint = typeBlueprint;


        gameBlueprints.Add(blue);
        blueprintBases.Add(blueBase);
    }
}