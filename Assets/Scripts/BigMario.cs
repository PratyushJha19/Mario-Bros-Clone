using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BigMario : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;

    Rigidbody2D rb2D;
    public bool isInAir = false;
    public bool rotatedRight = true;
    Animator playerAnim;
    public SmallMario smallMario;

    Vector2 leftCollisionForce = new Vector2(-700, 600);
    Vector2 rightCollisionForce = new Vector2(700, 600);

    void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        isInAir = false;
        rb2D = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Land" || collision.gameObject.tag != "LeftObstacle" || collision.gameObject.tag != "RightObstacle")
        {
            isInAir = false;
        }

        if (collision.gameObject.tag == null || (collision.gameObject.tag == "Invisible Collider"))
        {
            isInAir = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            InstantiateSmallMario();
        }
    }

    public void InstantiateSmallMario()
    {
        var instantiatedSmallMario = Instantiate(smallMario, gameObject.transform.position, Quaternion.identity);
        if(FindObjectsOfType<SmallMario>().Length > 1)
        {
            Destroy(instantiatedSmallMario.gameObject);
        }
        virtualCamera.Follow = instantiatedSmallMario.transform;
        Destroy(gameObject);
        if (rotatedRight == true)
        {
            rb2D.AddForce(leftCollisionForce);
        }

        else if (rotatedRight == false)
        {
            rb2D.AddForce(rightCollisionForce);
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
        Vector3 jumpValue = new Vector3(0, 1300);
        rb2D.AddForce(jumpValue);
    }
}
