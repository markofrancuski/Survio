using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [SerializeField] private List<Skill> _skills;

    private void Awake()
    {
        Instance = this;

        foreach (var skill in _skills)
        {
            if (skill.skillRequirements.Length > 0)
            {
                foreach (var req in skill.skillRequirements)
                {
                    req.skillRequirement.SkillLeveled += skill.CheckUnlock;
                }
            }      
        }
    }

    public Skill GetSkill(int index)
    {
        return _skills[index];
    }
    
    public bool GetSkillRequirements(int index)
    {
        return _skills[index].CheckRequirements();
    }

    public bool LevelUp(int index)
    {
        return _skills[index].LevelUp();
    }
    private void OnApplicationQuit()
    {
        
    }

}
