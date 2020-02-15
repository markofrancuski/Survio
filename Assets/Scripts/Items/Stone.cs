using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Pickup
{
    public override void PickUp()
    {
        InventoryManager.Instance.UpdateStone(Random.Range(HoldingItem.MinDrop, HoldingItem.MaxDrop));
        base.PickUp();
    }
}
