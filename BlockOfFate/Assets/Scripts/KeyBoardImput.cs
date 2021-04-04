using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardImput : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            PlayerController.instince.MovePlayer(1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            PlayerController.instince.MovePlayer(-1, 0);

        if (Input.GetKeyDown(KeyCode.A))
            PlayerController.instince.MovePlayer(0, 1);
        if (Input.GetKeyDown(KeyCode.D))
            PlayerController.instince.MovePlayer(0, -1);

    }
}
