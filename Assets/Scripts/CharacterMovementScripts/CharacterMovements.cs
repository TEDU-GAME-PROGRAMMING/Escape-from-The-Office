
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

    //**************************************************************************
    //**************************************************************************
    [Header("Movement for Sprint")]
    public float walkSpeed = 3.0f;
    public float sprintSpeed = 6.0f;

    [Header("Movement for Crounch")]
    public float crouchSpeed = 1.5f;  
    public float crouchYScale;
    private float startYScale;

    [Header("Keybindings for Sprint and Crounching")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
    }
    //**************************************************************************
    //**************************************************************************

    
    [Header("Inputs")]
    public float HorizontalInput;
    public float VerticalInput;
    public float MouseX;
    public float MouseY;


    //**************************************************************************
    //**************************************************************************
    private void Start(){

        startYScale = transform.localScale.y;
    }
    //**************************************************************************
    //**************************************************************************

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

        //**************************************************************************
        //**************************************************************************
         // start crouch
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 2f, ForceMode.Impulse);
        }

        // stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
        //**************************************************************************
        //**************************************************************************
    }
    void FixedUpdate()
    {
        if (isPlayerEnable)
        {
            HandleInputs();
            StateHandler();
        }
        
    }

    public void HandleInputs()
    {
        //Take inputs and handle these inputs with moving and rotating the character.
        
        
        MovementDirection = new Vector3(HorizontalInput/2, rb.velocity.y, VerticalInput);
        
        MovementDirection = transform.TransformDirection(MovementDirection);
        rb.velocity = MovementDirection;           
      
        
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

    
         //**************************************************************************
        //**************************************************************************
    private void StateHandler()
    {
        // Mode - Crouching
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            Speed = crouchSpeed;
        }

        // Mode - Sprinting
        else if(isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            Speed = sprintSpeed;
        }

        // Mode - Walking
        else if (isGrounded)
        {
            state = MovementState.walking;
            Speed = walkSpeed;
        }

    }
        //**************************************************************************
        //**************************************************************************
    
}
