using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBump : MonoBehaviour
{
    public GameObject mushroomEnemy;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Attacked");
            mushroomEnemy.GetComponent<BoxCollider2D>().enabled = false;
            rb2D.gravityScale = 1;
            Destroy(mushroomEnemy.gameObject, 3);
        }
    }
}
