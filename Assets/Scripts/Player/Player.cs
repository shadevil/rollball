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
    //[SerializeField] private AudioClip roll;
    //[SerializeField] private AudioClip fall;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        ballRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float hor = 0;
        float horJoystick = joystick.Horizontal;
        float horMouse = Input.GetAxis("Horizontal");
        if (horJoystick != 0) hor = horJoystick;
        if (horMouse != 0) hor = horMouse;
        else audioSource.Stop();
        ballRb.AddForce(hor * speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
