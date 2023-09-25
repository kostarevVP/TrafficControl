using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrafficLightTouchDetector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Action<PointerEventData> OnDetectTouchEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        //OnDetectTouchEvent?.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnDetectTouchEvent?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //OnDetectTouchEvent?.Invoke(eventData);
    }
}
