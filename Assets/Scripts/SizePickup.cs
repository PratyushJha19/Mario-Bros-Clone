using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePickup : MonoBehaviour
{
    CinemachineVirtualCamera cinemachine;
    public GameObject bigMario;
    public SmallMario smallMario;

    void Start()
    {
        cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveValue = new Vector3(2, 0);
        transform.position += moveValue * 2 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Small Mario")
        {
            Destroy(gameObject);
            smallMario = FindObjectOfType<SmallMario>();
            Destroy(smallMario.gameObject);

            var instantiatedBigMario = Instantiate(bigMario, smallMario.transform.position, Quaternion.identity);
            int numBigMarios = FindObjectsOfType<BigMario>().Length;
            if (numBigMarios > 1)
            {
                Destroy(instantiatedBigMario);
            }

            cinemachine.Follow = instantiatedBigMario.transform;
        }
    }
}
