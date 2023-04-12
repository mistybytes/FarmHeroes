using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject item;

    [HideInInspector] public Transform parentAfterDrag;

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Raycast(false);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       transform.SetParent(parentAfterDrag);
        Raycast(true);
    }

    void Raycast(bool enable)
    {
        if (enable)
        {
            item.GetComponent<Image>().raycastTarget = true;
            Image[] images = item.GetComponentsInChildren<Image>();
            foreach (Image image in images)
            {
                image.raycastTarget = true;
            }
            Text[] texts = item.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                text.raycastTarget = true;
            }
        }
        else
        {
            item.GetComponent<Image>().raycastTarget = false;
            Image[] images = item.GetComponentsInChildren<Image>();
            foreach (Image image in images)
            {
                image.raycastTarget = false;
            }
            Text[] texts = item.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                text.raycastTarget = false;
            }
        }

    }
}
