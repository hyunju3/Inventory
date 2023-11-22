using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrrInventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            TrrInventoryItem trrInventoryItem = eventData.pointerDrag.GetComponent<TrrInventoryItem>();
            trrInventoryItem.parentAfterDrag = transform;
        }
    }
}
