using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100f;
    public bool dead = false;
    public float fallThreshold = -10f;
    public Image healthBar;

    private void Update()
    {
        if (transform.position.y <= fallThreshold && !dead)
        {
            Die();
        }
    }

    public void getDamage(float damage)
    {
        if (health - damage > 0) {
            health -= damage;
        
        }
        else
        {
            health = 0;
        }
        UpdateHealthBar();
        amIdead();
    }
    void amIdead() { 
        if(health==0)
        {
            dead = true;
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Player is dead.");
        // Burada yeniden baþlatma iþlemini gerçekleþtirin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = health / 100f; // Health bar'ýn doluluk oranýný güncelle
    }
}
