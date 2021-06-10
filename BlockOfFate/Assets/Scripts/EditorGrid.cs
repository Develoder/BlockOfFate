using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorGrid : MonoBehaviour
{
    [SerializeField] private Transform[] _childrenTransforms;
    [SerializeField] private Transform[] _cellTransforms;
    [SerializeField] private Transform obstacleParent;
    
    private static Transform obj;
    public static List<Vector3> obstacleTransforms;

    public static EditorGrid instance;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ObstacleUpdate();
        print(obstacleTransforms.Count);
    }

    public void Update()
    {
        if (Application.isPlaying)
            return;
        
        for (int i = 0; i < _childrenTransforms.Length; i++)
        {
            for (int j = 0; j < _childrenTransforms[i].childCount; j++)
            {
                obj = _childrenTransforms[i].GetChild(j);
                obj.position = Grid.RoundVector(obj.position);
            }
        }
        
        for (int i = 0; i < _cellTransforms.Length; i++)
        {
            _cellTransforms[i].position = Grid.RoundVector(_cellTransforms[i].position);
        }

        ObstacleUpdate();
    }

    private void ObstacleUpdate()
    {
        obstacleTransforms = new List<Vector3>();
        for (int i = 0; i < obstacleParent.childCount; i++)
        {
            foreach (Transform child in obstacleParent.GetChild(i))
            {
                if (child.name != "PointObstacle")
                    continue;
                
                foreach (Transform points in child)
                    obstacleTransforms.Add(points.position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
            return;
        
        Gizmos.color = Color.yellow;
        for (int i = 0; i < obstacleTransforms.Count; i++)
        {
            Gizmos.DrawCube(obstacleTransforms[i] + Vector3.up * 0.5f, Vector3.one);
        }
    }
}
