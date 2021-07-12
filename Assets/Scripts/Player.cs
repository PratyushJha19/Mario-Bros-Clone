using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;
    public bool isInAir = false;

    void Start()
    {
        isInAir = false;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 leftCollisionForce = new Vector2(-600, 1000);
        Vector2 rightCollisionForce = new Vector2(600, 1000);

        //if(collision.gameObject.tag == "Land")
        if (collision.gameObject.tag != null)
        {
            isInAir = false;
        }

        if (collision.gameObject.tag == "Left Collider")
        {
            rb2D.AddForce(leftCollisionForce);
            print("Life Lost");
        }

        if (collision.gameObject.tag == "Right Collider")
        {
            rb2D.AddForce(rightCollisionForce);
            print("Life Lost");
        }

        if (collision.gameObject.tag == "Attack Place")
        {
            print("Attacked");
        }
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isInAir == false)
        {
            Jump();
            isInAir = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && isInAir == false)
        {
            Jump();
            isInAir = true;
        }
    }

    void Move()
    {
        float movementSpeed = 4f;
        Vector3 moveValue = new Vector2(2, 0);
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveValue * movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveValue * movementSpeed * Time.deltaTime;
        }
    }

    void Jump()
    {
        Vector3 jumpValue = new Vector3(0, 1250);
        rb2D.AddForce(jumpValue);
    }
}