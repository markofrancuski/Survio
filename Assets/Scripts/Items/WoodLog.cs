using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLog : Pickup
{

    public override void PickUp()
    {
        InventoryManager.Instance.UpdateWood(Random.Range(HoldingItem.MinDrop, HoldingItem.MaxDrop));
        base.PickUp();
    }

}
