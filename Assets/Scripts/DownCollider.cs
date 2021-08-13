using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DownCollider : MonoBehaviour
{
    CinemachineVirtualCamera mainCamera;

    void Start()
    {
        mainCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var smallMario = FindObjectOfType<SmallMario>();
        var bigMario = FindObjectOfType<BigMario>();
        var fireBallMario = FindObjectOfType<FireBallMario>();
        if(collision.gameObject.tag == "Small Mario" || collision.gameObject.tag == "Big Mario" || collision.gameObject.tag == "Fire Ball Mario")
        {
            mainCamera.Follow = null;
            // TODO - Game Over Screen;
        }
    }
}