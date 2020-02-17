using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public BuildingInfo selectedBuilding;


    // Make
    private void Awake()
    {
        Instance = this;
    }

    public void OnBuildingClicked(int index)
    {
        if (!buildings[index].isUnlocked) return;

        //Set the building sprite to mousePosition
        //Unsubscribe from shooting
        BuildingClicked?.Invoke();
        /*for (int i = 0; i < buildings[index].resourceRequirements.Length; i++)
        {
            if ( !CheckResource(buildings[index]) ) return;
        }*/
    }

    public void OnBuildingPlaced()
    {
        //Subscribe Shooting Again
        BuildingPlaced?.Invoke(selectedBuilding);

        
    }

    public void OnBuildingPlacementCancel()
    {

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


}
