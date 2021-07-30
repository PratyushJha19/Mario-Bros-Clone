using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCrushedTurtle : MonoBehaviour
{
    Collider2D thisCollider2d;
    public Collider2D attackingCollider;
    public Collider2D parentCollider;

    void Start()
    {
        thisCollider2d = GetComponent<Collider2D>();
        Invoke("EnableCollider", 2f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire Ball Mario" || collision.gameObject.tag == "Small Mario" || collision.gameObject.tag == "Big Mario")
        {
            attackingCollider.enabled = false;
            parentCollider.enabled = false;
            GetComponentInParent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void EnableCollider()
    {
        thisCollider2d.enabled = true;
    }
}
