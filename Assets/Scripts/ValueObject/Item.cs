using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int id;
    public Sprite icon;

    public Item(Item item)
    {
        name = item.name;
        id = item.id;
        icon = item.icon;
    }
}
