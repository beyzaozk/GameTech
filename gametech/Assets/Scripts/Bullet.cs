using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    public float endTime;
    
    public GameObject Bulletimpact;
    
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*bulletSpeed;
        Destroy(gameObject,endTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("can azaldý");
            Destroy(gameObject);
        }

        GameObject delete=  Instantiate(Bulletimpact,transform.position, transform.rotation);
        Destroy(delete,0.333f);
    }

   
}
