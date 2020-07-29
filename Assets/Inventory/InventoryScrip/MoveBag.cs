using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour, IDragHandler
{
    public RectTransform currentRect;

    public void OnDrag(PointerEventData eventData)
    {
        //anchoredPosition中心锚点的位置
        //delta相对于上次事件，鼠标的相对移动。
        currentRect.anchoredPosition += eventData.delta;
    }

    void AWake()
    {
        currentRect.GetComponent<RectTransform>();
    }
}
