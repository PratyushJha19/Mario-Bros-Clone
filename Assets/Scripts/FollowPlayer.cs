using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool playerIsMoving = false;
    public Transform mario;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void RawCamMVT()
    {
        float movementSpeed = 4f;
        Vector3 moveValue = new Vector2(2, 0);
        if (playerIsMoving == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += moveValue * movementSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position -= moveValue * movementSpeed * Time.deltaTime;
            }
        }
    }
}