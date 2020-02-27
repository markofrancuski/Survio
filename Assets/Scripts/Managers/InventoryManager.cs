using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skill_System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public delegate void ResourcesInteractedEventDelegate(ResourceType type, float val );
    public static event ResourcesInteractedEventDelegate ResourceChanged;

    private Dictionary<ResourceType, FloatValue> dictionary = new Dictionary<ResourceType, FloatValue>();


    /* public float Wood;
    public float Stone;
    public float IronOre;*/
    [Header("Scriptable Values")]
    public FloatValue Wood;
    public FloatValue Stone;
    public FloatValue IronOre;
    public IntValue SkillPoints;

    private void Awake()
    {
        Instance = this;
        //Binds resources with values for checking
        dictionary.Add(ResourceType.WOOD, Wood);
        dictionary.Add(ResourceType.STONE, Stone);
        dictionary.Add(ResourceType.IRON, IronOre);

        Sprite s =  Resources.Load<Sprite>("1.png");                
        Skill_System.Skill.Store.CreateSkill("Skill 1", "test skill name", "test skill desc", s, new List<SkillEffect>() { new DamageEffect() });
        Skill_System.Skill.Store.CreateSkill("Skill 2", "test skill name", "test skill desc", s, new List<SkillEffect>() { new DamageEffect(2) });
        Skill_System.Skill.Store.CreateSkill("Skill 3", "test skill name", "test skill desc", s, new List<SkillEffect>() { new DamageEffect(3) });
        Skill_System.Skill.Store.CreateSkill("Skill 4", "test skill name", "test skill desc", s, new List<SkillEffect>() { new DamageEffect(4) });
        Skill_System.Skill.Store.CreateSkill("Skill 5", "test skill name", "test skill desc", s, new List<SkillEffect>() { new DamageEffect(5) });
        Skill_System.Skill.Store.CreateSkill("Skill 6", "test skill name", "test skill desc", s, new List<SkillEffect>() { new DamageEffect(6) });

        var tree = SkillTree.Generator.testTree1();
        tree.GetSkillState("Skill 2").ApplyEffect(this);
        foreach (var skillState in tree.Enumerate())
        {
            if(skillState.Level > 0) skillState.ApplyEffect(this);
        }
    }

    private void Start()
    {
        ResourceChanged?.Invoke(ResourceType.WOOD, Wood.Value);
        ResourceChanged?.Invoke(ResourceType.STONE, Stone.Value);
        ResourceChanged?.Invoke(ResourceType.IRON, IronOre.Value);
    }
    public void UpdateWood(float amount)
    {
        Wood.Value += amount;
        ResourceChanged?.Invoke(ResourceType.WOOD, Wood.Value);
        ConsoleManger.Instance.DisplayNotification($"Aquired x{amount} Wood!");
    }

    public void UpdateStone(float amount)
    {
        Stone.Value += amount;
        ResourceChanged?.Invoke(ResourceType.STONE, Stone.Value);
        ConsoleManger.Instance.DisplayNotification($"Aquired x{amount} Stone!");
    }

    public void UpdateIron(float amount)
    {
        IronOre.Value += amount;
        ResourceChanged?.Invoke(ResourceType.IRON ,IronOre.Value);
        ConsoleManger.Instance.DisplayNotification($"Aquired x{amount} Iron!");
    }

    public string CheckResources(ResourceRequirement[] requirements)
    {
        float res = 0;
        string _returnMessage = string.Empty;
        if (requirements.Length <= 0) return _returnMessage;

        for (int i = 0; i < requirements.Length; i++)
        {
            res = GetResource(requirements[i].type);
            if (res < requirements[i].amount) return $"Insufficient resource({requirements[i].type}) you need:({requirements[i].amount}), and you have only:({res})";
        }

        return _returnMessage;
    }

    public string CheckSkills(SkillRequirement[] requirements)
    {
        string _returnMessage = string.Empty;
        if(requirements.Length <= 0) return _returnMessage;
        for (int i = 0; i < requirements.Length; i++)
        {
            if (requirements[i].skillRequirement.currentLevel < requirements[i].levelRequirement) return $"Skill {requirements[i].skillRequirement.sName} is not unlocked, you need level:{requirements[i].levelRequirement}, and its level: {requirements[i].skillRequirement.currentLevel}";
        }


        return _returnMessage;
    }

    public void ReduceResource(ResourceType type, float amount)
    {
        dictionary[type].Value -= amount;
        ResourceChanged?.Invoke(type, GetResource(type));
    }

    public float GetResource(ResourceType type)
    {
        return dictionary[type].Value;
    }
}
