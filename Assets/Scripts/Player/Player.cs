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
                audioSource.Play();
                rollSoundEnable = true;
            }
        }
        else
        {
            audioSource.Stop();
            rollSoundEnable = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hor==0 && collision.transform.tag == "MovingPlatform")
        {
            ballRb.velocity = Vector3.zero;
        }
        //audioSource.clip = fall;
        //audioSource.Play();
    }
}
