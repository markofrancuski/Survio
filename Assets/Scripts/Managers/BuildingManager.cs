using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    public enum BuildingState { WAITING, CHOSING_PLACE_TO_BUILD, FINISHED_BUILDING}

    public delegate void OnBuildingClickedEvent();
    public static event OnBuildingClickedEvent BuildingClicked;

    public delegate void OnBuildingPlacedEvent(BuildingInfo placedBuilding);
    public static event OnBuildingPlacedEvent BuildingPlaced;

    public delegate void OnBuildingPlacementCancelEvent();
    public static event OnBuildingPlacementCancelEvent BuildingPlacementCancel;

    [Space]
    public BuildingInfo[] buildings;

    [Space]
    public BuildingInfo selectedBuilding;
    [SerializeField] private bool isLocationValid = true;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        BuildingPlacementChecker.OnValidPlace += LocationValid;
        BuildingPlacementChecker.OnInvalidPlace += LocationInvalid;
    }

    private void OnDisable()
    {
        BuildingPlacementChecker.OnValidPlace -= LocationValid;
        BuildingPlacementChecker.OnInvalidPlace -= LocationInvalid;
    }

    public void OnBuildingClicked(int index)
    {
        if (!buildings[index].isUnlocked) return;

        //Unsubscribe from shooting
        selectedBuilding = buildings[index];
        BuildingClicked?.Invoke();
        Debug.Log("Clicked");
        /*for (int i = 0; i < buildings[index].resourceRequirements.Length; i++)
        {
            if ( !CheckResource(buildings[index]) ) return;
        }*/
    }

    public void OnTryBuildingPlace(Transform _placePosition)
    {
        string str;
        str = InventoryManager.Instance.CheckResources(selectedBuilding.resourceRequirements);
        //Check Resources
        if (str != string.Empty) throw new InsufficientResourceException(str);

        str = InventoryManager.Instance.CheckSkills(selectedBuilding.skillRequirements);
        //Check Skill
        if (str!= string.Empty) throw new SkillNotUnlockedException(str);

        //Check place building position
        if (!isLocationValid) throw new InvalidPlacementException($"Invalid location to place building, place is already occupied!");
        //Instantiate Object
        if(selectedBuilding.prefab == null) throw new NullReferenceException($"Selected building({selectedBuilding.bName}) does not have prefab assigned");
        Instantiate(selectedBuilding.prefab, _placePosition.position, _placePosition.rotation);

        //Reduce Resources
        for (int i = 0; i < selectedBuilding.resourceRequirements.Length; i++)
        {
            InventoryManager.Instance.ReduceResource(selectedBuilding.resourceRequirements[i].type, selectedBuilding.resourceRequirements[i].amount);
        }


        //Subscribe Shooting Again
        BuildingPlaced?.Invoke(selectedBuilding);     
    }

    public void OnBuildingPlacementCancel()
    {
        selectedBuilding = null;
        BuildingPlacementCancel?.Invoke();
    }

    private bool CheckResource(BuildingInfo bInfo)
    {
        if (bInfo.resourceRequirements.Length <= 0) return true;

        for (int i = 0; i < bInfo.resourceRequirements.Length; i++)
        {
            if (InventoryManager.Instance.GetResource(bInfo.resourceRequirements[i].type) > bInfo.resourceRequirements[i].amount) return false;
        }
        return true;
    }

    private void ReduceValues(BuildingInfo bInfo)
    {
        for (int i = 0; i < bInfo.resourceRequirements.Length; i++)
        {
            InventoryManager.Instance.ReduceResource(bInfo.resourceRequirements[i].type, bInfo.resourceRequirements[i].amount);
        }
    }

    private void LocationValid() => isLocationValid = true;
    private void LocationInvalid() => isLocationValid = false;
}
