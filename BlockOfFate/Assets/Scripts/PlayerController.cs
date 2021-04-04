using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instince;

    private Vector3 startPosition;

    private void Awake()
    {
        instince = this;
    }

    void Start()
    {
        startPosition = transform.position;
    }

    public void MovePlayer(int stepX, int stepY)
    {
        Grid.instance.MoveObject(transform, stepX, stepY);
    }

    public void ReturnStartPosition()
    {
        transform.position = startPosition;
        FormBlueprint.instance.StopRunBlueprint();
    }
}
