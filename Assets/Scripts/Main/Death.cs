﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D playerRb;
    public static bool IsFall = false;
    private Vector3 startPos = new Vector3(-8, 1);

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            IsFall = true;
            playerRb.velocity = Vector2.zero;
            other.gameObject.transform.position = other.gameObject.GetComponent<Player>().startPosition;
            IsFall = false;
        }
    }
}


//var FallItems = other.gameObject.GetComponents<FallingItem>();
//foreach (var item in FallItems)
//{
//    var FallItem = item as FallingItem;
//    if (FallItem != null)
//    {
//        Debug.Log("good");
//        other.gameObject.transform.position = item.startPosition;
//    }
//    else
//    {
//        Debug.Log("Falling object does not implements IFallingItem interface");
//        Application.Quit();
//    }
//}