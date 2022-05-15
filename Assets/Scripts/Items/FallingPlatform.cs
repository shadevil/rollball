using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Vector3 startPosition;
    private Rigidbody platformRb;
    private void Start()
    {
        startPosition = transform.position;
        platformRb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            platformRb.isKinematic = false;
        }        
    }
}
