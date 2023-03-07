using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : Entity
{
    private float horizontalInput;
    private float maxspeed = 10.0f;
    private float leftInput;
    private Animator animator;

    private SpriteRenderer mySpriteRenderer;
    public bool isFlipped { get; set;  }

    private bool isJumping = false;
    private bool isRunning = false;
    private bool isHit = false;
    private bool canJump = false;
    public float jumpForce = 3;

    float velocity;
    private Rigidbody2D rb;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void Update()
    {
        Move();
   

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
            // flip the sprite
            mySpriteRenderer.flipX = false;
            isFlipped=false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            canJump = !canJump;
            if(canJump)
            {
                velocity = jumpForce;
            }

            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

        }
        canJump = false;
        //}
    }



}


