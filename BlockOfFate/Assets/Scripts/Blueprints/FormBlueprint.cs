using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Панель шаблона
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

    // Запускает корутину на проигрывание всех нод
    public void RunBlueprint()
    {
        StopRunBlueprint();
        StartCoroutine(IERunBlueprint());
    }

    // Останавливает корутину
    public void StopRunBlueprint()
    {
        StopAllCoroutines();
    }

    // Метод идет по всем нодам и запускает их действие
    IEnumerator IERunBlueprint()
    {
        foreach (BlueprintBase blprBases in blueprintBases)
        {
            yield return new WaitForSeconds(timeSteep);
            blprBases.RunBlueprint();
        }
    }

    // Добавление ноды в шаблон
    public void AppendBlueprint(BlueprintBase.TypeBlueprint typeBlueprint)
    {
        print($"Blueprint is create {typeBlueprint}");
        GameObject blue = Instantiate(basePlane, content.transform);
        BlueprintBase blueBase = blue.GetComponent<BlueprintBase>();
        blueBase.typeBlueprint = typeBlueprint;


        gameBlueprints.Add(blue);
        blueprintBases.Add(blueBase);
    }

    // Удаление последней ноды из шаблона
    public void DeletedLastBlueprint()
    {
        if (gameBlueprints.Count == 0)
            return;
        DeleteBlueprint(gameBlueprints.Count - 1);
    }

    // Удаление всех нод из шаблона
    public void DeletedAllBlueprint()
    {
        if (gameBlueprints.Count == 0)
            return;
        while (gameBlueprints.Count > 0)
        {
            DeleteBlueprint(gameBlueprints.Count - 1);
        }
    }

    // Удаление ноды
    private void DeleteBlueprint(int index)
    {
        Destroy(gameBlueprints[index]);
        gameBlueprints.RemoveAt(index);
        blueprintBases.RemoveAt(index);
    }
}