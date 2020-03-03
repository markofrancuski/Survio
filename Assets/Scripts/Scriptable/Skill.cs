using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable/Skill", order = 0)]
public class Skill : ScriptableObject
{
    public delegate void OnSkillLeveledEventHandler();
    public event OnSkillLeveledEventHandler SkillLeveled;

    // Namestiti globalnu klasu za evente i svaki skill poseban key za event i kada se skill
    // namesti da povuce sve metode iz tog eventa i subuje ih ovde.

    public string sName;
    public string sDescription;
    public Sprite sIcon;

    public bool isUnlocked;

    [SerializeField] private int pointsCost;
    public int PointsCost
    {
        get { return pointsCost; }
    }
    [SerializeField] private int currentLevel;
    public int CurrentLevel
    {
        get { return currentLevel; }
    }
    [SerializeField] private int maxLevel;
    public int MaxLevel
    {
        get { return maxLevel; }
    }
    public SkillRequirement[] skillRequirements;

    private void Awake()
    {
    }
    public bool CheckRequirements()
    {
        if (skillRequirements.Length == 0) return true;
        //Loop thru other skills
        for (int i = 0; i < skillRequirements.Length; i++)
        {
            if (skillRequirements[i].skillRequirement.CurrentLevel < skillRequirements[i].levelRequirement) return false;
        }
        return true;
    }

    public bool LevelUp()
    {
        if (InventoryManager.Instance.SkillPoints.Value < pointsCost || currentLevel >= maxLevel || !CheckRequirements()) return false;
        //if (!isUnlocked) return;
          
        if (CurrentLevel == -1) currentLevel = 0;
        currentLevel++;
        SkillLeveled?.Invoke();
        ConsoleManger.Instance.DisplayNotification($"{sName} has been upgraded from: {currentLevel-1}, to: {currentLevel}");
        InventoryManager.Instance.SkillPoints.Value -= pointsCost;
        return true;
        //Logic for increasing skill points cost
    }

    public bool IsMax
    {
        get
        {
            if (currentLevel == -1 || currentLevel >= maxLevel) return false;
            return true;
        }
    }

    public void CheckUnlock()
    {
        if (skillRequirements.Length == 0)
        {
            currentLevel = 0;
            return;
        }
        //Loop thru other skills
        for (int i = 0; i < skillRequirements.Length; i++)
        {
            if (skillRequirements[i].skillRequirement.CurrentLevel < skillRequirements[i].levelRequirement) return;
        }

        currentLevel = 0;
    }
}
