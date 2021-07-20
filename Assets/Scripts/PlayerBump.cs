using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBump : MonoBehaviour
{
    public Transform enemy;
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
            enemy.GetComponentInChildren<BoxCollider2D>().enabled = false;
            rb2D.gravityScale = 1;
            Destroy(enemy.gameObject, 3);
        }
    }
}
