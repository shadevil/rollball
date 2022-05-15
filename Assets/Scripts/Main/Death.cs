using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody playerRb;
    public static bool IsFall = false;
    private Vector3 startPos = new Vector3(-8, 1);

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            IsFall = true;
            playerRb.velocity = Vector3.zero;
            other.gameObject.transform.position = other.gameObject.GetComponent<Player>().startPosition;
            IsFall = false;
        }
        if (other.transform.tag == "FallingPlatform") 
        {
            other.transform.position = other.gameObject.GetComponent<Cube>().startPosition;
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