using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 direction;
    private Vector3 endPosition;
    [SerializeField] private Vector3 delta = new Vector3(5,0);
    public float speed = 15f;
    private void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + delta;
    }
    void Update()
    {
        if (transform.position == startPosition) 
        {
            direction = endPosition;
        }
        if (transform.position == endPosition) 
        {
            direction = startPosition;
        }
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
}
