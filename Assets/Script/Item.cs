using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType 
{
    FarmTool,   // ���� ���
    CookTool,   // �丮 ���
    Crop,       // ���۹�
    Etc         // ��Ÿ
}

[System.Serializable]
public class Item
{
    public ItemType itmeType;
    public int itemId;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach (ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole(); 
        }

        return false;
    }
}
