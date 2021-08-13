using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePickupTile : MonoBehaviour
{
    public SpriteRenderer beforePickupTile;
    public SpriteRenderer afterPickupTile;

    void Start()
    {
        beforePickupTile.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Small Mario" || collision.gameObject.tag == "Big Mario")
        {
            beforePickupTile.enabled = true;
        }

        else if (collision.gameObject.tag == "Fire Ball Mario")
        {
            beforePickupTile.enabled = true;
        }
    }
}
