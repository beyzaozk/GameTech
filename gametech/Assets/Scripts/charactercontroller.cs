using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float speed = 5f;
    private GameObject heldTrash = null;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveCharacter();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldTrash == null)
            {
                PickUpTrash();
            }
            else
            {
                DropTrash();
            }
        }
    }

    void MoveCharacter()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }

    void PickUpTrash()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Trash"))
        {
            heldTrash = hit.collider.gameObject;
            heldTrash.transform.SetParent(transform);
            heldTrash.transform.localPosition = new Vector2(0, 1); // Karakterin elinde tutma pozisyonu
            heldTrash.GetComponent<Rigidbody2D>().isKinematic = true; // Hareketi kontrol etmek için
        }
    }

    void DropTrash()
    {
        heldTrash.transform.SetParent(null);
        heldTrash.GetComponent<Rigidbody2D>().isKinematic = false;
        heldTrash = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
