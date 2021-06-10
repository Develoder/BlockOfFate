using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс мировой сетки
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
    
    // Перемещает объект
    public void MoveObject(Transform transform, int stepX, int stepY)
    {
        Vector3 nextPosition = transform.position;
        nextPosition.x += sizeCell.x * stepX;
        nextPosition.z += sizeCell.y * stepY;
        
        if (OnObstacle(nextPosition))
            return;
        
        transform.position = nextPosition;
    }

    public static bool OnObstacle(Vector3 position)
    {
        for (int i = 0; i < EditorGrid.obstacleTransforms.Count; i++)
            if (EditorGrid.obstacleTransforms[i] == position)
                return true;
        return false;
    }
    
    public static Vector3 RoundVector(Vector3 vector)
    {
        Vector3 retVector = new Vector3(
            vector.x - (vector.x + offsetCell.x) % sizeCell.x,
            0,
            vector.z - (vector.z + offsetCell.y) % sizeCell.y);
        return retVector;
    }
}
