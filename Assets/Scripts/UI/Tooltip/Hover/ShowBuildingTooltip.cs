using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowBuildingTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public int _buildingIndex;
    [SerializeField] private int _tooltipIndex;
    [SerializeField] private Vector3 _position;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.Show(transform.position + _position, _tooltipIndex, BuildingManager.Instance.GetBuildingResourcesAsString(_buildingIndex) );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide(_tooltipIndex);
    }
}
