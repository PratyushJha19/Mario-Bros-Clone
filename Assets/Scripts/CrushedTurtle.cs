using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushedTurtle : MonoBehaviour
{
    public int speed = 5;
    public bool collidedWithPlayer = false;
    public bool collidedWithLeftObstacle = true;

    void Start()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Update()
    {
        if (collidedWithPlayer == true)
        {
            MoveLeft();
        }

        if (collidedWithLeftObstacle == true)
        {
            MoveRight();
        }

        else if (collidedWithLeftObstacle == false)
        {
            MoveLeft();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Small Mario" || collision.gameObject.tag == "Big Mario" || collision.gameObject.tag == "Fire Ball Mario")
        {
            collidedWithPlayer = true;
            collidedWithLeftObstacle = true;
        }

        if (collision.gameObject.tag == "RightObstacle")
        {
            collidedWithLeftObstacle = false;
        }

        else if (collision.gameObject.tag == "LeftObstacle")
        {
            collidedWithLeftObstacle = true;
        }
    }

    void MoveRight()
    {
        transform.position += new Vector3(3, 0) * speed * Time.deltaTime;
    }

    void MoveLeft()
    {
        Vector3 leftMovement = new Vector3(-3, 0);
        transform.rotation = new Quaternion(0, 180, 0, 0);
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
