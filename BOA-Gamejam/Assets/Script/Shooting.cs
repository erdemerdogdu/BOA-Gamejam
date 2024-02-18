using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform bulletTransform;
    public static bool CanFire;
    public static bool isDead = false;
    private float timer;
    public float timeBetweenFiring;

    private void Start()
    {
        isDead = false;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!isDead)
        {
            if(!CanFire)
            {
                timer += Time.deltaTime;
                if(timer > timeBetweenFiring)
                {
                    CanFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButton(0) && CanFire)
            {
                CanFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }
        else
        {
            return;
        }
        
        
    }
}
