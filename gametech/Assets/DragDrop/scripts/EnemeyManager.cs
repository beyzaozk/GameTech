using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyManager : MonoBehaviour
{

    public float health;
    public float damage;
    bool playerCollider = false;

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
