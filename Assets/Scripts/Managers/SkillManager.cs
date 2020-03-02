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
}
