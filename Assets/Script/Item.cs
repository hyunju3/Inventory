using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType 
{
    FarmTool,   // 농장 재료
    CookTool,   // 요리 재료
    Crop,       // 농작물
    Etc         // 기타
}

[System.Serializable]
public class Item
{
    public ItemType itmeType;
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
