using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillPanel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _availableSkillPointsText;

    public void UpdateSkillPoints() => _availableSkillPointsText.SetText(InventoryManager.Instance.SkillPoints.Value.ToString());

}
