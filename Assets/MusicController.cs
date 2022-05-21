using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<GameController>().gameEnd == true) audioSource.Pause();
        //if (gameController.GetComponent<GameController>().restartButton.On) audioSource.Play();
    }
}
