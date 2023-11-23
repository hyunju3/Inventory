using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrrInventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, noneColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = noneColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            TrrInventoryItem trrInventoryItem = eventData.pointerDrag.GetComponent<TrrInventoryItem>();
            trrInventoryItem.parentAfterDrag = transform;
        }
    }
}
