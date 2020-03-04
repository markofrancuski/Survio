using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowSkillRequirement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public int _skillIndex;
    [SerializeField] private int _tooltipIndex;
    [SerializeField] private Vector3 _position;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!SkillManager.Instance.ShouldShowRequirementTooltip(_skillIndex)) return;

        TooltipManager.Instance.Show(transform.position + _position, _tooltipIndex, SkillManager.Instance.GetSkillRequirementsAsString(_skillIndex) );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!SkillManager.Instance.ShouldShowRequirementTooltip(_skillIndex)) return;
        TooltipManager.Instance.Hide(_skillIndex);
    }

}
