using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    void Start()
    {
        Rigidbody[] allActiveElements = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody element in allActiveElements) 
        {
            element.isKinematic = true;
        }
    }
}
