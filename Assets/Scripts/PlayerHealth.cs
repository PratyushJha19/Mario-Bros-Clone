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

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            if (health <= 0)
            {
                anim.SetBool("Dead", true);
                GetComponent<SmallMario>().enabled = false;
                playerRb.velocity = new Vector2(0, 0);
                FindObjectOfType<Enemy>().enabled = false;
                FindObjectOfType<Enemy2>().enabled = false;
                virtualCamera.Follow = null;
                virtualCamera.LookAt = null;
                Invoke("PullPlayer", 1f);
            }
        }
    }

    void PullPlayer()
    {
        playerColliders[0].enabled = false;
        playerColliders[1].enabled = false;
        //playerRb.gravityScale = 1;
    }
}
