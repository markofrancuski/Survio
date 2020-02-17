using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Tree", menuName = "Scriptable/SkillTree", order = 0)]
public class SkillTree : ScriptableObject
{

    public string sName;
    public string sDescription;
    public Sprite sIcon;

    public bool isUnlocked;
    public int pointsCost;
    public SkillTree[] skillRequirements;
    
    public bool CheckRequirements()
    {
        if (skillRequirements.Length == 0 && isUnlocked) return true;
        //Loop thru other skills
        for (int i = 0; i < skillRequirements.Length; i++)
        {
            if (!skillRequirements[i].isUnlocked) return false;
        }
        return true;
    }

}
