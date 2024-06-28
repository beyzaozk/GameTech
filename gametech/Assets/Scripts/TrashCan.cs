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
                // ��p do�ru ��p kutusuna b�rak�ld�
                Destroy(collision.gameObject); // ��p� yok et veya ba�ka bir i�lem yap
            }
            else
            {
                Debug.Log("Incorrect drop");
                // ��p yanl�� ��p kutusuna b�rak�ld�
                // Burada ba�ka bir i�lem yapabilirsiniz
            }
        }
    }
}
