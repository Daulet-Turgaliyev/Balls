using System;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovement : NetworkBehaviour
{
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedRotation;

    private Rigidbody rigidbody;
    
    private Vector2 _direction => MainInputController.Instance.Movement;
    private Vector2 _rotation => MainInputController.Instance.Mouse;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (isLocalPlayer == false) Destroy(this);
    }

    private void FixedUpdate()
    {
        Movement(); 
        Rotation();
    }

    private void Movement()
    {
        rigidbody.AddRelativeForce(new Vector3(_direction.x, 0f, _direction.y) * speed, ForceMode.Acceleration);
    }

    private void Rotation()
    {
        transform.Rotate(0,_rotation.x/speedRotation,0);
    }
}
