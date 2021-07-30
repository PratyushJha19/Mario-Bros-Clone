using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlePlayerHit : MonoBehaviour
{
    public GameObject turtleEnemy;
    public GameObject crushedTurtle;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Big Mario" || collision.gameObject.tag == "Small Mario" || collision.gameObject.tag == "Fire Ball Mario")
        {
            Destroy(turtleEnemy.gameObject);
            Instantiate(crushedTurtle, this.transform.position, Quaternion.identity);
        }
    }
}