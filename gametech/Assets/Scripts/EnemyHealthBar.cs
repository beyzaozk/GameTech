using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemeyManager enemyManager;
    public Image healthBarFill;

    void Update()
    {
        if (enemyManager != null)
        {
            healthBarFill.fillAmount = enemyManager.health / 100f;
        }
    }
}
