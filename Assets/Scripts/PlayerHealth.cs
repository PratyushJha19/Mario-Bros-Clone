using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    Animator anim;
    Rigidbody2D playerRb;
    BoxCollider2D[] playerColliders;
    public int health = 2;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        playerColliders = GetComponents<BoxCollider2D>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            if (health <= 0)
            {
                Die2();
            }
        }

        //if (collision.gameObject.tag == "Crushed Turtle Hitter")
        //{
        //    Die();
        //}
    }

    private void Die2()
    {
        anim.SetBool("Dead", true);
        GetComponent<SmallMario>().enabled = false;
        playerRb.velocity = new Vector2(0, 0);
        FindObjectOfType<Enemy2>().enabled = false;
        FindObjectOfType<TurtleEnemy>().enabled = false;
        FindObjectOfType<Enemy>().enabled = false;
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        Invoke("PullPlayer", 1f);
    }

    public void Die()
    {
        print("small mario");
        anim.SetBool("Dead", true);
        GetComponent<SmallMario>().enabled = false;
        virtualCamera.Follow = null;
        FindObjectOfType<CrushedTurtle>().enabled = false;
        virtualCamera.LookAt = null;
        Invoke("PullPlayer", 1f);
    }

    void PullPlayer()
    {
        playerColliders[0].enabled = false;
        playerColliders[1].enabled = false;
        //playerRb.gravityScale = 1;
    }
}
