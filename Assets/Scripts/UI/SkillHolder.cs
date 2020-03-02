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
    [SerializeField] private Skill _skill;

    public int SkillIndex;

    private void Awake()
    {
        _skill = SkillManager.Instance.GetSkill(SkillIndex);
    }

    private void Start()
    {
        _skillNameText.SetText(_skill.sName);
        if(_skill.CurrentLevel> 0) _skillCurrentLevelText.SetText($"{_skill.CurrentLevel}");
        else _skillCurrentLevelText.SetText($"{0}");
        _skillMaxLevelText.SetText($"/{_skill.MaxLevel}");
        if (_skill.MaxLevel == _skill.CurrentLevel) _button.interactable = false;
    }

    private void UpdateLevel() => _skillCurrentLevelText.SetText($"{_skill.CurrentLevel}");

    public void OnButtonClick()
    {
        if (SkillManager.Instance.LevelUp(SkillIndex)) UpdateLevel();
    }

    private void OnEnable()
    {
        //Check button interaction
        _button.interactable = _skill.IsMax;
    }
}
