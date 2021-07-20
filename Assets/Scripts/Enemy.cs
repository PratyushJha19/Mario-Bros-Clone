using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1.2f;
    public bool collidedWithLeftObstacle = false;

    void Start()
    {

    }

    void Update()
    {
        if(collidedWithLeftObstacle == false)
        {
            MoveLeft();
        }
        else if (collidedWithLeftObstacle == true)
        {
            MoveRight();
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "LeftObstacle")
        {
            collidedWithLeftObstacle = true;
            print("Reverted Direction");
            //MoveRight();
        }

        else if (collision.gameObject.tag == "RightObstacle")
        {
            collidedWithLeftObstacle = false;
        }
    }

    void MoveRight()
    {
        Vector3 rightMovement = new Vector3(2, 0);
        transform.position += rightMovement * movementSpeed * Time.deltaTime;
    }

    void MoveLeft()
    {
        Vector3 leftMovement = new Vector3(-2, 0);
        transform.position += leftMovement * movementSpeed * Time.deltaTime;
    }
}