using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 startPosition;
    public float speed = 1000f;
    [SerializeField] private Joystick joystick;
    private Rigidbody2D ballRb;
    private float hor = 0;
    [SerializeField] private bool IsJoystickEnable;
    private void Start()
    {
        startPosition = transform.position;
        ballRb = GetComponent<Rigidbody2D>();
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
        if (hor != 0) ballRb.AddForce(new Vector2(hor * speed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision){ if (hor == 0) ballRb.velocity = Vector2.zero; }
}
