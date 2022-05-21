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
    private Button startButton;
    public Button restartButton 
    {
        get 
        {
            return endCanvas.gameObject.GetComponentInChildren<Button>();
        }
    }
    public bool gameEnd = false;
    void Start()
    {
        startCanvas.gameObject.SetActive(true);
        endCanvas.gameObject.SetActive(false);
        joystick.SetActive(false);
        player.SetActive(false);
        startButton = startCanvas.gameObject.GetComponentInChildren<Button>();
        startButton.onClick.AddListener(() => StartGame(startCanvas));
        restartButton.onClick.AddListener(() => StartGame(endCanvas));
        elementsRb = activeElements.GetComponentsInChildren<Rigidbody>();
    }
    private void FreezeGame() 
    {
        foreach (Rigidbody rb in elementsRb) rb.isKinematic = true; //Freeze active elements
        player.SetActive(false); //Hide player
        joystick.SetActive(false); //Hide joystick
    }
    private void UnfreezeGame() 
    {
        gameEnd = false;
        foreach (Rigidbody rb in elementsRb) rb.isKinematic = false; //Unfreeze active elements
        player.SetActive(true); //Show player
        player.transform.position =
            player.GetComponent<Player>().startPosition; //Move player to start
        joystick.SetActive(true); //Hide joystick
    }
    private void StartGame(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
        UnfreezeGame();
    }

    private void RestartGame(Canvas canvas)
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
