using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyManager : MonoBehaviour
{

    public float healtk;
    public float damage;


    bool playerColladier=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player"&& !playerColladier)
        {
            playerColladier = true;
            other.GetComponent<PlayerManager>().getDamage(damage);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerColladier = false;
        }
    }
}
