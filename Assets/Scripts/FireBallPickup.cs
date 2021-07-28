using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FireBallPickup : MonoBehaviour
{
    public FireBallMario fireBallMario;
    public BigMario bigMario;
    CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Big Mario")
        {
            Destroy(gameObject);
            bigMario = FindObjectOfType<BigMario>();
            var instantiatedFireBallMario= Instantiate(fireBallMario, bigMario.transform.position, Quaternion.identity);
            virtualCamera.Follow = instantiatedFireBallMario.transform;
            Destroy(bigMario.gameObject);
        }
    }
}
