using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementChecker : MonoBehaviour
{
    public delegate void PlaceLocationValidatorEventHandler();

    public static event PlaceLocationValidatorEventHandler OnValidPlace;
    public static event PlaceLocationValidatorEventHandler OnInvalidPlace;

    [SerializeField] private bool isActive;

    private void OnEnable()
    {
        BuildingManager.BuildingClicked += StartChecking;
        BuildingManager.BuildingPlacementCancel += StopChecking;
    }

    private void OnDisable()
    {
        BuildingManager.BuildingClicked -= StartChecking;
        BuildingManager.BuildingPlacementCancel -= StopChecking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive && collision.CompareTag("Building"))
        {
            OnInvalidPlace?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isActive && collision.CompareTag("Building"))
        {
            OnValidPlace?.Invoke();
        }
    }

    private void StartChecking() => isActive = true;
    private void StopChecking() => isActive = false;
}
