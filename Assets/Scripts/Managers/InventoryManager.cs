using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public delegate void ResourcesInteractedEventDelegate(ResourceType type, float val );
    public static event ResourcesInteractedEventDelegate ResourceChanged;

    private Dictionary<ResourceType, FloatValue> dictionary = new Dictionary<ResourceType, FloatValue>();


    /* public float Wood;
     public float Stone;
     public float IronOre;*/

    public FloatValue Wood;
    public FloatValue Stone;
    public FloatValue IronOre;

    private void Awake()
    {
        Instance = this;
        //Binds resources with values for checking
        dictionary.Add(ResourceType.WOOD, Wood);
        dictionary.Add(ResourceType.STONE, Stone);
        dictionary.Add(ResourceType.IRON, IronOre);
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
