using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    public float JumpForce;
    public float Speed;
    private Vector3 _moveVector;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //Move
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector += -transform.right;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }
    }
    void FixedUpdate()
    {
        //Move
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);
        if(_characterController.isGrounded) 
        {
            _fallVelocity = 0;
        }
        //Gravity
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(_fallVelocity * Time.fixedDeltaTime * Vector3.down);
    }
}
