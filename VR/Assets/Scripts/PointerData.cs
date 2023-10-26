using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerData : MonoBehaviour, IPointerDownHandler
{
    public Scrollbar scrollbar;
    public void OnPointerDown(PointerEventData eventData)
    {
        scrollbar.OnPointerDown(eventData);
    }

    public void Check()
    {
        OnPointerDown(null);
    }

}
