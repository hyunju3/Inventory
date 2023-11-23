using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;
    public GameObject InventoryPanel;
    bool activeInventory = false;
    public int pluseCount;

    public Slot[] slots;
    public Transform slotHolder;

    void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        InventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;

            if (i<inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    void Update()
    {
        InputM();
    }

    void InputM()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }

    void OpenInventory()
    {
        activeInventory = !activeInventory;
        InventoryPanel.SetActive(activeInventory);
    }

    public void AddSlot()
    {
        for (int i = 0; i < pluseCount; i++)
        {
            inven.SlotCnt++; 
        }
    }

    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}

