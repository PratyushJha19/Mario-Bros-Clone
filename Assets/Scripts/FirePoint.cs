using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var instantiatedBullets = Instantiate(bullet, this.transform.position, Quaternion.identity);
        Destroy(instantiatedBullets.gameObject, 5f);
    }
}
