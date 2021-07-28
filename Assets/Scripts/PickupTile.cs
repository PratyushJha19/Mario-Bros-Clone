using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTile : MonoBehaviour
{
    public int tileHealth = 1;
    public GameObject afterHitTile;
    public GameObject[] pickup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Small Mario")
        {
            tileHealth -= 1;
            Destroy(gameObject);
            afterHitTile.SetActive(true);
            pickup[0].SetActive(true);
        }

        else if (collision.gameObject.tag == "Big Mario" /* || collision.gameObject.tag == "Fire Ball Mario" */)
        {
            tileHealth -= 1;
            Destroy(gameObject);
            afterHitTile.SetActive(true);
            pickup[1].SetActive(true);
        }
    }
}
