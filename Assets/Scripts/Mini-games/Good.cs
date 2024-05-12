using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public enum Goods
{
    Milk,
    Meat,
    Sweets,
    Box
}

public class Good : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Goods _goodType;

    private Canvas _canvas;
    private ContentSizeFitter _parent;
    private CanvasGroup _goodsPanel;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    public Goods GoodType => _goodType;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
        transform.parent = _goodsPanel.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        transform.parent = _parent.transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void Initialize(Canvas canvas, ContentSizeFitter parent, CanvasGroup goodsPanel)
    {
        _canvas = canvas;
        _parent = parent;
        _goodsPanel = goodsPanel;
    }
}
