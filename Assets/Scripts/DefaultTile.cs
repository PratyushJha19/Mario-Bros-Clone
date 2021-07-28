using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTile : MonoBehaviour
{
    public GameObject parent;
    public GameObject shatterTile;
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Big Mario"|| collision.gameObject.tag == "Fire Ball Mario")
        {
            Destroy(parent.gameObject);
            var instantiatedShatterTile = Instantiate(shatterTile, gameObject.transform.position, Quaternion.identity);
            Destroy(instantiatedShatterTile.gameObject, .1f);
        }
    }
}
