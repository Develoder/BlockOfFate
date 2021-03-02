using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardImput : MonoBehaviour
{
    [SerializeField] private MoveGrid _moveGrid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _moveGrid.MoveObject(1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            _moveGrid.MoveObject(-1, 0);

        if (Input.GetKeyDown(KeyCode.A))
            _moveGrid.MoveObject(0, 1);
        if (Input.GetKeyDown(KeyCode.D))
            _moveGrid.MoveObject(0, -1);

    }
}
