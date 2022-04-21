
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

public class CharacterMovements : MonoBehaviour
{
    //TODO Sprint and crouch will be added.
    
    public Rigidbody rb;
    public bool isPlayerEnable = true; // false when character reaches the end.
    public bool isGrounded = true; // true when character is landed after jump.
    public bool isJumped = false;
    [Header("Movement Settings")]
    public float Speed = 250.0f;
    public float JumpForce = 5000f;
    public float MouseSensivity = 5f;
    public Vector3 MovementDirection = Vector3.zero;
    
    [Header("Inputs")]
    public float HorizontalInput;
    public float VerticalInput;
    public float MouseX;
    public float MouseY;

    void Update()
    {
        //Take inputs
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumped = true;
        }

        if (!isJumped)
        {
            HorizontalInput = Input.GetAxis("Horizontal") * Speed;
            VerticalInput = Input.GetAxis("Vertical") * Speed;
        }
        MouseX = Input.GetAxis("Mouse X") * MouseSensivity;
        MouseY = -Input.GetAxis("Mouse Y") * MouseSensivity;
    }
    void FixedUpdate()
    {
        if (isPlayerEnable)
        {
            HandleInputs();
        }
        
    }

    public void HandleInputs()
    {
        //Take inputs and handle these inputs with moving and rotating the character.
        
        
        MovementDirection = new Vector3(HorizontalInput/2, rb.velocity.y, VerticalInput);
        
        MovementDirection = transform.TransformDirection(MovementDirection);
        if (isGrounded )
        {
            rb.velocity = MovementDirection;           
        }
        
        //Jump
        if (isJumped && isGrounded)
        {
            isGrounded = false;
            isJumped = false;
            rb.AddForce(new Vector3(0,JumpForce,0));
        }
        
        
        //Mouse rotation
        transform.Rotate(new Vector3(0,MouseX,0));
    }


    private void OnCollisionStay(Collision other)
    {
        
        //If collided object is Ground, then isGrounded is True.
        //Ground Checker Part of the character is entered the ground when it is landed after jump.
        if (other.gameObject.CompareTag("Ground") )
        {
            isGrounded = true;

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }
}
