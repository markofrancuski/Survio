using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skillNameText;
    [SerializeField] private TextMeshProUGUI _skillCurrentLevelText;
    [SerializeField] private TextMeshProUGUI _skillMaxLevelText;
    [SerializeField] private Button _button;
    public Skill skill;

    private void Start()
    {
        _skillNameText.SetText(skill.sName);
        _skillCurrentLevelText.SetText($"{skill.currentLevel}");
        _skillMaxLevelText.SetText($"/{skill.maxLevel}");
        if (skill.maxLevel == skill.currentLevel) _button.interactable = false;

    }

    public void OnButtonClick()
    {
        if (skill.currentLevel >= skill.maxLevel || !skill.isUnlocked) return;
        Debug.Log("Level up Clicked");
        skill.LevelUp(() => {
            _skillCurrentLevelText.SetText($"{skill.currentLevel}");
        });
    }
}
