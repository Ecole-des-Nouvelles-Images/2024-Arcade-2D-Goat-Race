using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;
    [SerializeField] private float smoothTime = 0.001f;
    [SerializeField] private Transform target;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = target.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(_rigidbody2D.velocity);
        if (_rigidbody2D.velocity.y < -15f)
        {
            offset.y = -2;
            Debug.Log(" la cam doit se mettre en dessous"); 
        }
        else
        {
            offset.y = 2;
            Debug.Log(" la cam doit se mettre au millieu"); 
        }


        Vector3 targetPosition = target.position;
       transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime * Time.deltaTime);
    }
}
