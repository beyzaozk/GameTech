using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private string acceptedTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            if (collision.gameObject.tag == acceptedTag)
            {
                Debug.Log("Correct drop");
                // Çöp doðru çöp kutusuna býrakýldý
                Destroy(collision.gameObject); // Çöpü yok et veya baþka bir iþlem yap
            }
            else
            {
                Debug.Log("Incorrect drop");
                // Çöp yanlýþ çöp kutusuna býrakýldý
                // Burada baþka bir iþlem yapabilirsiniz
            }
        }
    }
}
