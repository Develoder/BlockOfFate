using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Vector2 _sizeCell = new Vector2(1, 1);
    public Vector2 SizeCell
    {
        get
        {
            if (_sizeCell.x != 0 || _sizeCell.y != 0)
                return _sizeCell;
            return new Vector2(0.1f, 0.1f);
        }
    }

    [SerializeField] private Vector2 _ofsetCell = new Vector2(0.5f, 0.5f);
    public Vector2 OfsetCell
    {
        get
        {
            if (_ofsetCell.x != 0 || _ofsetCell.y != 0)
                return _ofsetCell;
            return new Vector2(0.1f, 0.1f);
        }
    }

    private List<List<GameObject>> _gridObject = new List<List<GameObject>>();

}
