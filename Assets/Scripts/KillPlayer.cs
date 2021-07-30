using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    Collider2D thisRb2D;
    public Collider2D parentRb2D;

    void Start()
    {
        thisRb2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Small Mario")
        {
            print("Player Hurt");
            FindObjectOfType<SmallMario>().GetComponent<PlayerHealth>().Die();
        }

        if (collision.gameObject.tag == "Big Mario")
        {
            print("big mario hurt");
            FindObjectOfType<BigMario>().InstantiateSmallMario();
        }

        if (collision.gameObject.tag == "Fire Ball Mario")
        {
            print("fire ball mario hurt");
            FindObjectOfType<FireBallMario>().InstantiateSmallMario();
        }

        if (collision.gameObject.tag == "Fire Ball")
        {
            thisRb2D.enabled = false;
            parentRb2D.enabled = false;
        }
    }
}