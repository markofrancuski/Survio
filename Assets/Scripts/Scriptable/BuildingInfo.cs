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
    public SkillTree[] skillRequirements;

    public GameObject prefab;

    public bool CheckSkillRequirements()
    {
        for (int i = 0; i < skillRequirements.Length; i++)
        {
            if (!skillRequirements[i].isUnlocked) return false;
        }
        return true;
    }

    public string[] ResourcesAsString()
    {
        int index = 2 + (resourceRequirements.Length * 2);

        int resourceIndex = 0;
        string[] strs = new string[index];

        strs[0] = bName;
        strs[1] = bDescription;

        for (int i = 2; i < index; i+=2)
        {
            strs[i] = resourceRequirements[resourceIndex].type.ToString();
            strs[i+1] = resourceRequirements[resourceIndex].amount.ToString();
            resourceIndex++;
        }
        return strs;
   }

}

[Serializable]
public class ResourceRequirement
{
    public ResourceType type;
    public float amount;

}

