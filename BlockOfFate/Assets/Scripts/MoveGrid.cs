using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrid : MonoBehaviour
{
    private Grid _grid;

    private Vector2 _sizeCell;

    private Vector3 _addPosititon = new Vector3(0, 0, 0);

    void Start()
    {
        _grid = GameObject.Find("Grid").GetComponent<Grid>();

        _sizeCell = _grid.SizeCell;
    }

    public void MoveObject(int stepX, int stepY)
    {
        _addPosititon.x = _sizeCell.x* stepX;
        _addPosititon.z = _sizeCell.y* stepY;

        transform.position += _addPosititon;
    }
}
