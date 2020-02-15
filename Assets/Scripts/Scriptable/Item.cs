using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/Item", order = 0)]
public class Item : ScriptableObject
{
    public string ItemName;
    public string ItemDescription;
    public bool isUnique;
    public int MaxStack;

    public int MinDrop;
    public int MaxDrop;

}
