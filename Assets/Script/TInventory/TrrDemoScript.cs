using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrrDemoScript : MonoBehaviour
{
    public TrrInventoryManager trrInventoryManager;
    public TrrItem[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = trrInventoryManager.AddItem(itemsToPickup[id]);

        if (result == true)
        {
            Debug.Log("Item 추가");
        } 
        else 
        {
            Debug.Log("Item 추가 실패");
        }
    }

    public void GetSelectedItem()
    {
        TrrItem receivedItem = trrInventoryManager.GetSelectedItem();
        Debug.Log("ReceivedItem 수신성공");

        if (receivedItem != null)
        {
            Debug.Log("버릴 아이템이: " + receivedItem);
        }
        else
        {
            Debug.Log("버릴 아이템이 존재하지 않음");
        }
    }
}
