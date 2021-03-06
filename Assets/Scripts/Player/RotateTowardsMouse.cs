﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    public Vector3 lookDirection;

    public bool CheckForInput = true;

    private void OnEnable()
    {
        CanvasManager.CanvasPaused += () => CheckForInput = false;
        CanvasManager.CanvasUnpaused += () => CheckForInput = true;
    }

    private void OnDisable()
    {
        CanvasManager.CanvasPaused -= () => CheckForInput = false;
        CanvasManager.CanvasUnpaused -= () => CheckForInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Take Mouse Position
        if (!CheckForInput) return;

        //Calculate the direction between mouseposition and player position
        lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position).normalized;

        //Rotate towards the mouse

        _transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg);
    }
}
