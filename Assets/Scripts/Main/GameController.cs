using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject activeElements;
    private Rigidbody[] elementsRb;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject joystick;
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Canvas endCanvas;
    public bool gameEnd = false;
    void Start()
    {
        startCanvas.gameObject.SetActive(true);
        endCanvas.gameObject.SetActive(false);
        joystick.SetActive(false);
        player.SetActive(false);
        Button startButton = startCanvas.gameObject.GetComponentInChildren<Button>();
        Button restartButton = startCanvas.gameObject.GetComponentInChildren<Button>();
        startButton.onClick.AddListener(() => StartGame(startCanvas));
        restartButton.onClick.AddListener(() => StartGame(endCanvas));
        elementsRb = activeElements.GetComponentsInChildren<Rigidbody>();
    }
    private void FreezeGame() 
    {
        #region Freeze active elements
        foreach (Rigidbody rb in elementsRb)
        {
            rb.isKinematic = true;
        }
        #endregion
        player.SetActive(false); //Hide player
        joystick.SetActive(false); //Hide joystick
    }
    private void UnfreezeGame() 
    {
        #region Unfreeze active elements
        foreach (Rigidbody rb in elementsRb)
        {
            rb.isKinematic = false;
        }
        #endregion
        player.SetActive(true); //Hide player
        player.transform.position =
            player.GetComponent<Player>().startPosition; //Move player to start
        joystick.SetActive(true); //Hide joystick
    }
    private void StartGame(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
        UnfreezeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd) 
        {
            endCanvas.gameObject.SetActive(true);
        }
    }
}
