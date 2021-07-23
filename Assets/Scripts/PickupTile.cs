using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTile : MonoBehaviour
{
    public int tileHealth = 1;
    public GameObject afterHitTile;
    public GameObject pickup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tileHealth -= 1;
            Destroy(gameObject);
            afterHitTile.SetActive(true);
            pickup.SetActive(true);
        }
    }
}
