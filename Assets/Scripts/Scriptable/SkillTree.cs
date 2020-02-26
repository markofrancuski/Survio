using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable/Skill", order = 0)]
public class Skill : ScriptableObject
{
    public delegate void OnSkillUnlockEventHandler();
    public event OnSkillUnlockEventHandler SkillUnlocked;

    // Namestiti globalnu klasu za evente i svaki skill poseban key za wevent i kada se skill
    // namesti da povuce sve metode iz tog eventa i subuje ih ovde.

    public string sName;
    public string sDescription;
    public Sprite sIcon;

    public bool isUnlocked;
    public int pointsCost;
    public int currentLevel = 0;
    public int maxLevel = 0;

    public SkillRequirement[] skillRequirements;

    public void CheckRequirements()
    {
        if (skillRequirements.Length == 0 && currentLevel != 0) isUnlocked = true;

        //Loop thru other skills
        for (int i = 0; i < skillRequirements.Length; i++)
        {
            if (!skillRequirements[i].skillRequirement.isUnlocked) return;
        }
        isUnlocked = true;
    }

    public void LevelUp(UnityAction callback)
    {
        //if (!isUnlocked) return;
        if (InventoryManager.Instance.SkillPoints.Value >= pointsCost)
        {
            currentLevel++;
            if (currentLevel == 1) isUnlocked = true;
            ConsoleManger.Instance.DisplayNotification($"{sName} has been upgraded from: {currentLevel - 1}, to: {currentLevel}");
            InventoryManager.Instance.SkillPoints.Value -= pointsCost;
            callback();
            //Logic for increasing skill points cost
        }
    }

    public void Unlock()
    {
        isUnlocked = true;
        SkillUnlocked?.Invoke();
    }
}
