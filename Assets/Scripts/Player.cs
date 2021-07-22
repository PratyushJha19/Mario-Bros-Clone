using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;
    public bool isInAir = false;
    public bool rotatedRight = true;
    Animator playerAnim;

    void Start()
    {
        isInAir = false;
        rb2D = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 leftCollisionForce = new Vector2(-700, 600);
        Vector2 rightCollisionForce = new Vector2(700, 600);

        if (collision.gameObject.tag != null)
        {
            isInAir = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (rotatedRight == true)
            {
                rb2D.AddForce(leftCollisionForce);
                print("Damaged R");
            }

            else if (rotatedRight == false)
            {
                rb2D.AddForce(rightCollisionForce);
                print("Damaged L");
            }
        }
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isInAir == false)
        {
            playerAnim.SetBool("Jump", true);
            Jump();
            isInAir = true;
        }

        else if (Input.GetKeyDown(KeyCode.W) && isInAir == false)
        {
            playerAnim.SetBool("Jump", true);
            Jump();
            isInAir = true;
        }

        else
        {
            playerAnim.SetBool("Jump", false);
        }
    }

    void Move()
    {
        float movementSpeed = 4f;
        Vector3 moveValue = new Vector2(2, 0);
        //FindObjectOfType<FollowPlayer>().playerIsMoving = true;

        if (Input.GetKey(KeyCode.D) && rotatedRight == false)
        {
            transform.position += moveValue * movementSpeed * Time.deltaTime;
            RotateRight();
            rotatedRight = true;
            playerAnim.SetBool("Walk", true);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveValue * movementSpeed * Time.deltaTime;
            playerAnim.SetBool("Walk", true);
        }

        else if (Input.GetKey(KeyCode.A) && rotatedRight == true)
        {
            transform.position -= moveValue * movementSpeed * Time.deltaTime;
            RotateLeft();
            rotatedRight = false;
            playerAnim.SetBool("Walk", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveValue * movementSpeed * Time.deltaTime;
            playerAnim.SetBool("Walk", true);
        }

        else { playerAnim.SetBool("Walk", false); }
    }

    private void RotateLeft()
    {
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void RotateRight()
    {
        /* new Vector2(0, 0) */
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Jump()
    {
        Vector3 jumpValue = new Vector3(0, 1250);
        rb2D.AddForce(jumpValue);
    }
}