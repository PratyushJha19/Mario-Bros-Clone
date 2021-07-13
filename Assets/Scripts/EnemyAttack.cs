using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform enemy;
    public GameObject mushroomEnemy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Attacked");
            enemy.GetComponentInChildren<BoxCollider2D>().enabled = false;
            mushroomEnemy.AddComponent<Rigidbody2D>();
            Destroy(enemy.gameObject, 3);
        }
    }
}
