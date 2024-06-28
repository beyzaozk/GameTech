using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private string acceptedTag;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            // ��p nesnesinin RectTransform bile�enini al
            RectTransform droppedRectTransform = droppedObject.GetComponent<RectTransform>();
            RectTransform slotRectTransform = GetComponent<RectTransform>();

            // ��p nesnesinin Draggable scriptini al
            NewBehaviourScript draggable = droppedObject.GetComponent<NewBehaviourScript>();

            if (droppedRectTransform != null && slotRectTransform != null && draggable != null)
            {
                // ��p�n tag'inin ��p kutusunun kabul edece�i tag ile e�le�ip e�le�medi�ini kontrol et
                if (droppedObject.tag == acceptedTag)
                {
                    // ��p do�ru ��p kutusuna b�rak�ld�
                    Debug.Log("Correct drop");
                    droppedRectTransform.anchoredPosition = slotRectTransform.anchoredPosition;
                }
                else
                {
                    // ��p yanl�� ��p kutusuna b�rak�ld�
                    Debug.Log("Incorrect drop");
                    // Burada ��p� geri alabilir veya ba�ka bir i�lem yapabilirsiniz
                    // �rne�in, ��z� geri eski pozisyonuna koymak:
                    draggable.ResetPosition();
                }
            }
            else
            {
                Debug.LogWarning("Missing RectTransform or Draggable component on dropped object or slot");
            }
        }
        else
        {
            Debug.LogWarning("No pointerDrag object found in event data");
        }

        //if (eventData.pointerDrag != null )
        //{
        //    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //}
    }
}
