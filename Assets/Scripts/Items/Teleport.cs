using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject end;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TEST!");
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.transform.position = end.transform.position;
    }
}
