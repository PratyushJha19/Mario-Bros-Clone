using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float health = 3;
    public Rigidbody2D rb;
    public float speed = 10;

    void Start()
    {
        BulletMove();
    }

    void BulletMove()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RightObstacle" || collision.gameObject.tag == "LeftObstacle")
        {
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag == "Pickup Tile" || collision.gameObject.tag == "Default Tile")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Invisible Collider")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Crushed Turtle" || collision.gameObject.tag == "Crushed Turtle Hitter")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Building Block")
        {
            Destroy(gameObject);
        }
    }
}