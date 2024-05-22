using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoodTaker : MonoBehaviour, IDropHandler
{
    [SerializeField] private Goods _goodType;

    public static event Action<Good> GoodTaked;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null )
        {
            if(eventData.pointerDrag.GetComponent<Good>().GoodType == _goodType)
            {
                GoodTaked?.Invoke(eventData.pointerDrag.GetComponent<Good>());
                Destroy(eventData.pointerDrag.GetComponent<RectTransform>().gameObject);
            }
        }
    }
}
