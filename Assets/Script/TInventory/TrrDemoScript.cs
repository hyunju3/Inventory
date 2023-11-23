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
            Debug.Log("Item �߰�");
        } 
        else 
        {
            Debug.Log("Item �߰� ����");
        }
    }

    public void GetSelectedItem()
    {
        TrrItem receivedItem = trrInventoryManager.GetSelectedItem();
        Debug.Log("ReceivedItem ���ż���");

        if (receivedItem != null)
        {
            Debug.Log("���� ��������: " + receivedItem);
        }
        else
        {
            Debug.Log("���� �������� �������� ����");
        }
    }
}
