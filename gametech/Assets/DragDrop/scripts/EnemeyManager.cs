using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyManager : MonoBehaviour
{
    [SerializeField] private GameObject redParticles;
    public float health = 100f;
    public float damage;
    bool playerCollider = false;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(redParticles, transform.position, transform.rotation);
            Destroy(gameObject);
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        // Öldüðünde yapýlacaklar
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player"&& !playerCollider)
        {
            playerCollider = true;
            other.GetComponent<PlayerManager>().getDamage(damage);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerCollider = false;
        }
    }
}
