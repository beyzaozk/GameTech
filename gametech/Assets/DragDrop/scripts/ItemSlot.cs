using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private string acceptedTag;
    private static int correctDrops = 0;
    private static int requiredCorrectDrops = 3;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            // Çöp nesnesinin RectTransform bileþenini al
            RectTransform droppedRectTransform = droppedObject.GetComponent<RectTransform>();
            RectTransform slotRectTransform = GetComponent<RectTransform>();

            // Çöp nesnesinin Draggable scriptini al
            NewBehaviourScript draggable = droppedObject.GetComponent<NewBehaviourScript>();

            if (droppedRectTransform != null && slotRectTransform != null && draggable != null)
            {
                // Çöpün tag'inin çöp kutusunun kabul edeceði tag ile eþleþip eþleþmediðini kontrol et
                if (droppedObject.tag == acceptedTag)
                {
                    // Çöp doðru çöp kutusuna býrakýldý
                    Debug.Log("Correct drop");
                    droppedRectTransform.anchoredPosition = slotRectTransform.anchoredPosition;

                    // Sayaç güncelleme
                    correctDrops++;
                    Debug.Log("Correct drops: " + correctDrops);

                    if (correctDrops >= requiredCorrectDrops)
                    {
                        ProceedToNextSection();
                    }
                }
                else
                {
                    // Çöp yanlýþ çöp kutusuna býrakýldý
                    Debug.Log("Incorrect drop");
                    // Burada çöpü geri alabilir veya baþka bir iþlem yapabilirsiniz
                    // Örneðin, çözü geri eski pozisyonuna koymak:
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
    }
    private void ProceedToNextSection()
    {
        // Burada diðer bölüme geçiþ iþlemini yapýn
        Debug.Log("Proceeding to the next section!");
        // Örneðin, yeni bir sahneye geçmek için:
        SceneManager.LoadScene("Bolum2");
    }
}
