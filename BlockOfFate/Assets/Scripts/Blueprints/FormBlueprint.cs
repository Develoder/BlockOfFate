using System;
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

    public static FormBlueprint instance;

    private List<GameObject> gameBlueprints = new List<GameObject>();
    public List<BlueprintBase> blueprintBases = new List<BlueprintBase>();

    private void Awake()
    {
        instance = this;
    }

    public void RunBlueprint()
    {
        StopRunBlueprint();
        StartCoroutine(IERunBlueprint());
    }

    public void StopRunBlueprint()
    {
        StopAllCoroutines();
    }

    IEnumerator IERunBlueprint()
    {
        foreach (BlueprintBase blprBases in blueprintBases)
        {
            yield return new WaitForSeconds(timeSteep);
            blprBases.RunBlueprint();
        }
    }

    public void AppendBlueprint(BlueprintBase.TypeBlueprint typeBlueprint)
    {
        print($"Blueprint is create {typeBlueprint}");
        GameObject blue = Instantiate(basePlane, content.transform);
        BlueprintBase blueBase = blue.GetComponent<BlueprintBase>();
        blueBase.typeBlueprint = typeBlueprint;


        gameBlueprints.Add(blue);
        blueprintBases.Add(blueBase);
    }

    public void DeletedLastBlueprint()
    {
        if (gameBlueprints.Count == 0)
            return;
        DeleteBlueprint(gameBlueprints.Count - 1);
    }

    public void DeletedAllBlueprint()
    {
        if (gameBlueprints.Count == 0)
            return;
        while (gameBlueprints.Count > 0)
        {
            DeleteBlueprint(gameBlueprints.Count - 1);
        }
    }

    private void DeleteBlueprint(int index)
    {
        Destroy(gameBlueprints[index]);
        gameBlueprints.RemoveAt(index);
        blueprintBases.RemoveAt(index);
    }
}