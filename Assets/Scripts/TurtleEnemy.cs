using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEnemy : MonoBehaviour
{
    public float movementSpeed = 1.2f;
    public bool collidedWithLeftObstacle = false;

    void Start()
    {

    }

    void Update()
    {
        if (collidedWithLeftObstacle == false)
        {
            MoveLeft();
        }
        else if (collidedWithLeftObstacle == true)
        {
            MoveRight();
            //transform.Rotate(0, 180, 0);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftObstacle")
        {
            collidedWithLeftObstacle = true;
            //print("Reverted Direction");
            //MoveRight();
        }

        else if (collision.gameObject.tag == "RightObstacle")
        {
            collidedWithLeftObstacle = false;
        }

        else if (collision.gameObject.tag == "Fire Ball")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(gameObject, 3);
        }
    }

    void MoveRight()
    {
        Vector3 rightMovement = new Vector3(2, 0);
        transform.position += rightMovement * movementSpeed * Time.deltaTime;
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    void MoveLeft()
    {
        Vector3 leftMovement = new Vector3(-2, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position += leftMovement * movementSpeed * Time.deltaTime;
    }
}