using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShowBuildingTooltip))]
public class BuildingButtonClick : ButtonClick
{
    [SerializeField] private Image _image;
    [SerializeField] private int _buildingIndex;

    private void Start()
    {
        _buildingIndex = GetComponent<ShowBuildingTooltip>()._buildingIndex;

        _image.sprite = BuildingManager.Instance.buildings[_buildingIndex].bIcon;
    }

    public override void OnButtonClick()
    {
        BuildingManager.Instance.OnBuildingClicked(_buildingIndex);
        {

        }
    }
}
