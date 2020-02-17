using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _targetTransform;

    [SerializeField] private float smoothing;

    [SerializeField] private Vector3 targetPosition = Vector3.zero;

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

    private void Start()
    {
        targetPosition.z = -10f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!CheckForInput) return;

        if(_targetTransform.position != transform.position)
        {
            targetPosition.x = _targetTransform.position.x;
            targetPosition.y = _targetTransform.position.y;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
