using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Scriptable/BuildingInfo", order = 0)]
public class BuildingInfo : ScriptableObject
{
    public string bName;
    public string bDescription;
    public Sprite bIcon;

    public bool isUnlocked;
    public ResourceRequirement[] resourceRequirements;
    public SkillRequirement[] skillRequirements;

    public GameObject prefab;

    public bool CheckSkillRequirements()
    {
        for (int i = 0; i < skillRequirements.Length; i++)
        {
                if (skillRequirements[i].skillRequirement.CurrentLevel < skillRequirements[i].levelRequirement) return false;
        }
        return true;
    }

    public string[] ResourcesAsString()
    {
        int index = 2 + ((resourceRequirements.Length * 2) + (skillRequirements.Length * 2));

        int resourceIndex = 0;
        int skillIndex = 0;
        string[] strs = new string[index];

        strs[0] = bName;
        strs[1] = bDescription;

        for (int i = 2; i <= index / 2 ; i += 2)
        {
            strs[i] = resourceRequirements[resourceIndex].type.ToString();
            strs[i + 1] = resourceRequirements[resourceIndex].amount.ToString();
            resourceIndex++;
        }
        int skillStartingIndex = index / 2 + 2;

        if (skillRequirements.Length > 0)
        { 
            for (int i = skillStartingIndex; i < skillStartingIndex+ skillRequirements.Length; i += 2)
            {
                strs[i] = skillRequirements[skillIndex].skillRequirement.sName;
                strs[i + 1] = skillRequirements[skillIndex].levelRequirement.ToString();
                skillIndex++;
            }
        }
        return strs;
   }

    public void CheckUnlock()
    {
        isUnlocked = false;
        return;
        // POGLEDATI OVO

        isUnlocked = true;
    }
}

[Serializable]
public class ResourceRequirement
{
    public ResourceType type;
    public float amount;

}
[Serializable]
public class SkillRequirement
{
    public Skill skillRequirement;
    public int levelRequirement;

}
