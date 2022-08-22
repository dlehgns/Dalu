using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapMove : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            if (rectTransform.anchoredPosition.x > 0)
            {
                rectTransform.anchoredPosition = new Vector2(0, rectTransform.anchoredPosition.y);
            }

            if (rectTransform.anchoredPosition.x < -3070)
            {
                rectTransform.anchoredPosition = new Vector2(-3070, rectTransform.anchoredPosition.y);
            }

            if (rectTransform.anchoredPosition.y > 0)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
            }

            if (rectTransform.anchoredPosition.y < -1474)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -1474);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
