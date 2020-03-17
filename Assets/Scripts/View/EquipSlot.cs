using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : Slot
{
    public SpriteRenderer equipRenderer;
    private Sprite originalSprite;

    private void Awake()
    {
        originalSprite = equipRenderer.sprite;
    }

    public override void SetItem(Item item)
    {
        base.SetItem(item);
        if (item == null)
        {
            equipRenderer.sprite = originalSprite;
        }
        else
        {
            equipRenderer.sprite = item.icon;
        }
    }
}
