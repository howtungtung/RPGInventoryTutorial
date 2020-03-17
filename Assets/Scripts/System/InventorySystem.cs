using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public StatusView statusView;
    public ItemDatabase itemDatabase;
    public PlayerData playerData;
    private Slot[] slots;
    

    public bool isDragging
    {
        private set;
        get;
    }
    private Slot dragSlot;

    private void Awake()
    {
        slots = GetComponentsInChildren<Slot>();
        foreach(Slot slot in slots)
        {
            slot.SetInventory(this);
        }
        playerData = SaveSystem.Load<PlayerData>("playerData");
    }

    private void Start()
    {
        Refresh();
    }

    private void OnDisable()
    {
        Save();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveSystem.Save("playerData", playerData);
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        statusView.UpdateStatusMesh(playerData.GetNormalizedStatus());
        if (playerData.ownItems != null)
        {
            if (playerData.ownItems.Length > slots.Length)
            {
                throw new Exception("Player's items exceed slot limit");
            }
            for (int i = 0; i < playerData.ownItems.Length; i++)
            {
                Item item = itemDatabase.GetItem(playerData.ownItems[i]);
                slots[i].SetItem(item);
            }
        }
    }

    public void BeginDraggingSession(Slot dragSlot)
    {
        isDragging = true;
        this.dragSlot = dragSlot;
        dragSlot.iconImage.transform.SetParent(transform);
    }

    public void EndDraggingSession(Slot dropSlot)
    {
        if(dropSlot != null)
        {
            Item dropSlotItem = dropSlot.Item;
            dropSlot.SetItem(dragSlot.Item);
            dragSlot.SetItem(dropSlotItem);
        }
        dragSlot.iconImage.transform.SetParent(dragSlot.transform);
        dragSlot.iconImage.transform.localPosition = Vector3.zero;
        dragSlot = null;
        isDragging = false;
    }
}
