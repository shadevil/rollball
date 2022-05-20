using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 startPosition;
    public float speed = 1000f;
    [SerializeField] private Joystick joystick;
    private Rigidbody ballRb;
    private float hor = 0;
    [SerializeField] private bool IsJoystickEnable;
    private void Start()
    {
        startPosition = transform.position;
        ballRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || !IsJoystickEnable)
        {
            hor = Input.GetAxis("Horizontal");          
        }
        if (Application.platform == RuntimePlatform.Android || IsJoystickEnable) 
        {
            hor = joystick.Horizontal;
        }
        if (hor != 0) ballRb.AddForce(hor * speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision) { if (hor == 0) ballRb.velocity = Vector3.zero; }
}
