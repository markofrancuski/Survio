using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : Pickup
{
    public override void PickUp()
    {
        InventoryManager.Instance.UpdateIron( Random.Range(HoldingItem.MinDrop, HoldingItem.MaxDrop));
        base.PickUp();
    }

}
