using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : Entity
{
    private float horizontalInput;
    private float maxspeed = 2.5f;
    private float leftInput;
    private Animator animator;
    Rigidbody m_Rigidbody;

    private SpriteRenderer mySpriteRenderer;
    public bool isFlipped { get; set;  }

    private bool isJumping = false;
    private bool isRunning = false;
    
    private bool canJump = false;
    bool onGround;

    public float jumpForce = 3;

    float velocity;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        tag = "Player";
        isFlipped = false;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Check if the player is currently jumping
        if (isJumping)
        {
            animator.SetBool("isJump", true);
            // Check if the player is now grounded
            if (IsGrounded())
            {
                // Switch to the running animation
                isJumping = false;
                //animator.Play("Player_Run", 0);
                animator.SetBool("isJump", false);
            }
        }
    }

    private void Update()
    {


            //Move();

            //// Check if the player is currently jumping
            //if (isJumping)
            //{
            //    // Check if the player is now grounded
            //    if (IsGrounded())
            //    {
            //        // Switch to the running animation
            //        animator.Play("Player_Run", 0);
            //        isJumping = false;
            //    }s

            //if (Input.GetKeyDown(KeyCode.Mouse0)) {
            //    animator.Play("Player_Attack", 0);
            //};
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            Jump();

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            isRunning = !isRunning;

            Debug.Log("left");

            // if the variable isn't empty (we have a reference to our SpriteRenderer
            if (mySpriteRenderer != null)
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
                isFlipped = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isRunning = !isRunning;
            Debug.Log("Right");
            // flip the sprite
            mySpriteRenderer.flipX = false;
            isFlipped = false;
        }
    }
    public bool getFlipped()
    {
        return isFlipped;
    }
    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
        animator.SetFloat("Speed", inputMagnitude,0.05f,Time.deltaTime);
        float speed = inputMagnitude * maxspeed;
        moveDirection.Normalize();

        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);
    }

  
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        position.y += transform.localScale.y / 2f;
        float distance = 1.0f;
        Debug.DrawRay(position, direction, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    void Jump()
    {
        // Jump...
        rb.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
        //animator.Play("Player_Jump", 0);
        Debug.Log("hello");
    }
}


