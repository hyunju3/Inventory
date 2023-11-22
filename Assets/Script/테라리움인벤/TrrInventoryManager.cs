using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrrInventoryManager : MonoBehaviour
{
    public TrrInventorySlot[] trrInventorySlots;
    public GameObject inventoryItemPrefab;
    public void AddItem(TrrItem trrItem)
    {
        for (int i = 0; i < trrInventorySlots.Length; i++)
        {
            TrrInventorySlot slot = trrInventorySlots[i];
            TrrInventoryItem trritemInSlot = slot.GetComponentInChildren<TrrInventoryItem>();
            if (trritemInSlot == null)
            {
                SpawnNewItem(trrItem, slot);
                return;
            }
        }
    }

    void SpawnNewItem(TrrItem trrItem, TrrInventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        TrrInventoryItem trrInventoryItem = newItemGo.GetComponentInChildren<TrrInventoryItem>();
        trrInventoryItem.InitialiseItem(trrItem);
    }
}
