using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrrInventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;

    [HideInInspector] public TrrItem trrItem;
    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        InitialiseItem(trrItem);
    }

    public void InitialiseItem(TrrItem newItem)
    {
        trrItem = newItem;
        image.sprite = newItem.image;
    }
    // Drag and drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
