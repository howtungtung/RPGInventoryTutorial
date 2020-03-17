using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class ItemDatabase : ScriptableObject
{
    public Item[] allItems;

    public Item GetItem(int id)
    {
        Item item = Array.Find(allItems, data => data.id == id);
        if(item == null)
        {
            throw new Exception("Item id " + id + " not exist in item database");
        }
        Item newItem = new Item(item);
        return newItem;
    }
}