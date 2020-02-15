using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public delegate void ResourcesInteractedEventDelegate(ResourceType type, float val);
    public static event ResourcesInteractedEventDelegate ResourceChanged;

    public float Wood;
    public float Stone;
    public float IronOre;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResourceChanged?.Invoke(ResourceType.WOOD, Wood);
        ResourceChanged?.Invoke(ResourceType.STONE, Stone);
        ResourceChanged?.Invoke(ResourceType.IRON, IronOre);
    }
    public void UpdateWood(float amount)
    {
        Wood += amount;
        ResourceChanged?.Invoke(ResourceType.WOOD, Wood);
        ConsoleManger.Instance.DisplayNotification($"Aquired x{amount} Wood!");
    }

    public void UpdateStone(float amount)
    {
        Stone += amount;
        ResourceChanged?.Invoke(ResourceType.STONE, Stone);
        ConsoleManger.Instance.DisplayNotification($"Aquired x{amount} Stone!");
    }

    public void UpdateIron(float amount)
    {
        IronOre += amount;
        ResourceChanged?.Invoke(ResourceType.IRON ,IronOre);
        ConsoleManger.Instance.DisplayNotification($"Aquired x{amount} Iron!");
    }



}
