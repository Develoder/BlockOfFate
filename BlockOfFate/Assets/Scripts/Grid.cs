using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Vector2 sizeCell = new Vector2(1, 1);
    public static Vector2 offsetCell = new Vector2(0.5f, 0.5f);

    private List<List<GameObject>> _gridObject = new List<List<GameObject>>();
    
    public static Grid instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void MoveObject(Transform transform, int stepX, int stepY)
    {
        Vector3 _addPosititon = new Vector3();
        _addPosititon.x = sizeCell.x * stepX;
        _addPosititon.z = sizeCell.y * stepY;

        transform.position += _addPosititon;
    }
    
    
}
