using UnityEngine;
using UnityEngine.EventSystems;

public class GoodTaker : MonoBehaviour, IDropHandler
{
    [SerializeField] private Goods _goodType;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Good>().GoodType == _goodType)
        {
            Destroy(eventData.pointerDrag.GetComponent<RectTransform>().gameObject);
        }
    }
}
