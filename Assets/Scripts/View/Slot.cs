using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private InventorySystem inventory;
    public Image iconImage;

    public Item Item
    {
        private set;
        get;
    }

    public void SetInventory(InventorySystem inventory)
    {
        this.inventory = inventory;
    }

    public virtual void SetItem(Item item)
    {
        Item = item;
        if (Item == null)
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
        else
        {
            iconImage.sprite = Item.icon;
            iconImage.enabled = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Item == null)
            return;
        inventory.BeginDraggingSession(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (inventory.isDragging)
        {
            iconImage.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inventory.isDragging)
        {
            inventory.EndDraggingSession(null);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (inventory.isDragging)
        {
            inventory.EndDraggingSession(this);
        }
    }
}
