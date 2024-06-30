using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }

    }
    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, transform.rotation);
    }
}
