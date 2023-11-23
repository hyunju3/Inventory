using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrrInventoryManager : MonoBehaviour
{
    public int maxStackedItems = 4;
    public TrrInventorySlot[] trrInventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        InputM();
    }

    private void InputM()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
                ChangeSelectedSlot(number - 1);
        }
    }

    void ChangeSelectedSlot(int val)
    {
        if (selectedSlot >= 0)
            trrInventorySlots[selectedSlot].Deselect(); 

        trrInventorySlots[val].Select();
        selectedSlot = val;
    }
    public bool AddItem(TrrItem trrItem) {
        #region �κ��丮 ������ ī��Ʈ �߰� ��
        for (int i = 0; i < trrInventorySlots.Length; i++)
        {
            TrrInventorySlot slot = trrInventorySlots[i];
            TrrInventoryItem trritemInSlot = slot.GetComponentInChildren<TrrInventoryItem>();
            /* ����
                1. ������ ������ null ���� �ƴ� ���
                2. ������ ������ �������� ������ �������� ���
                3. ������ ������ �������� max���� �ʰ����� �������
                4. ������ ������ �������� stackable ���� ���� ���
            */
            if (trritemInSlot != null &&
                trritemInSlot.trrItem == trrItem &&
                trritemInSlot.count < maxStackedItems &&
                trritemInSlot.trrItem.stackable == true)
            {
                trritemInSlot.count++;
                trritemInSlot.RefreshCount();
                return true;
            }
        } 
        #endregion
        #region �κ��丮 ������ �߰� ��
        for (int i = 0; i < trrInventorySlots.Length; i++)
        {
            TrrInventorySlot slot = trrInventorySlots[i];
            TrrInventoryItem trritemInSlot = slot.GetComponentInChildren<TrrInventoryItem>();
            if (trritemInSlot == null)
            {
                SpawnNewItem(trrItem, slot);
                return true;
            }
        } 
        #endregion
        return false;
    }

    void SpawnNewItem(TrrItem trrItem, TrrInventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        TrrInventoryItem trrInventoryItem = newItemGo.GetComponentInChildren<TrrInventoryItem>();
        trrInventoryItem.InitialiseItem(trrItem);
    }

    public TrrItem GetSelectedItem()
    {
        TrrInventorySlot slot = trrInventorySlots[selectedSlot];
        TrrInventoryItem itemInSlot = slot.GetComponentInChildren<TrrInventoryItem>();
        if (itemInSlot != null)
        {
            return itemInSlot.trrItem;
        }
        return null;
    }
}
