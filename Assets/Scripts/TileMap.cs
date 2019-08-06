using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    private Rigidbody myRigidbody;

    void Awake()
    {

        myRigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        


    }

    private void OnTriggerEnter(Collider collider)
    {

        //Debug.Log("Collide");

        //if (CompareTag("Player"))
        //    myRigidbody.isKinematic = false;

    }
}
