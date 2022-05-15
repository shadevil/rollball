using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SetActive(false);
        gameController.GetComponent<GameController>().gameEnd = true;
    }
}
