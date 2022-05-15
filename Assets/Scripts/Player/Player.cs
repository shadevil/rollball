using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 startPosition;
    public float speed = 1000f;
    [SerializeField] private Joystick joystick;
    private Rigidbody ballRb;
    private AudioSource audioSource;
    private float hor = 0;
    private bool rollSoundEnable = false;
    private bool fallSoundEnable = false;
    private float oldmass;
    [SerializeField] private AudioClip roll;
    [SerializeField] private AudioClip fall;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        ballRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            hor = Input.GetAxis("Horizontal");          
        }
        if (Application.platform == RuntimePlatform.Android) 
        {
            hor = joystick.Horizontal;
        }
        if (hor != 0)
        {
            ballRb.AddForce(hor * speed * Time.deltaTime, 0, 0);
            audioSource.clip = roll;
            if (!rollSoundEnable)
            {
                Debug.Log("ROLL");
                rollSoundEnable = true;
            }
        }
        else
        {
            rollSoundEnable = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!fallSoundEnable)
        {
            Debug.Log("FALL");

            audioSource.clip = fall;
            fallSoundEnable = true;
        }
        else
        {
            fallSoundEnable = false;
        }

        if (hor == 0 && collision.transform.tag == "MovingPlatform")
        {
            ballRb.velocity = Vector3.zero;
            oldmass = ballRb.mass;
            ballRb.mass = 5;
        }
        //else ballRb.mass = oldmass;
    }
}
