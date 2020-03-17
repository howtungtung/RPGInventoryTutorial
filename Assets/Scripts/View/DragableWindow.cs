using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragableWindow : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Vector2 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 centerPos = transform.position;
        offset = centerPos - eventData.position;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + offset;
    }
}
