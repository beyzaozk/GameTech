using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jumpAudioSource; // Zýplama sesi için
    [SerializeField] private AudioSource transitionAudioSource; // Bölüm geçiþ sesi için
    

    private GameObject heldObject = null;
    private Transform holdPoint;

    private void Start()
    {
        holdPoint = new GameObject("HoldPoint").transform;
        holdPoint.SetParent(transform);
        holdPoint.localPosition = new Vector3(0.5f, 0, 0); // Karakterin önünde bir nokta
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetBool("isRunning", horizontal != 0);
        animator.SetBool("isJumping", !IsGrounded() && rb.velocity.y > 0);
        animator.SetBool("isFalling", !IsGrounded() && rb.velocity.y < 0);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }


        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (heldObject != null)
        {
            heldObject.transform.position = holdPoint.position;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        
        

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            holdPoint.localPosition = new Vector3(holdPoint.localPosition.x * -1f, holdPoint.localPosition.y, holdPoint.localPosition.z); // HoldPoint'i yansýt
        }
    }

    private void TryPickUpObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Trash"))
            {
                heldObject = collider.gameObject;
                heldObject.GetComponent<Rigidbody2D>().isKinematic = true;
                heldObject.transform.SetParent(holdPoint);
                break;
            }
        }
    }

    private void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody2D>().isKinematic = false;
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Portal"))
        {
            transitionAudioSource.Play(); // Bölüm geçiþ sesini çal
            // Bölüm geçiþ iþlemlerini burada yapýn
        }
    }
}
