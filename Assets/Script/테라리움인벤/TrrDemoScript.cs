using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrrDemoScript : MonoBehaviour
{
    public TrrInventoryManager trrInventoryManager;
    public TrrItem[] itemsToPickup;

    public void PickupItem(int id)
    {
        trrInventoryManager.AddItem(itemsToPickup[id]);
    }
}
