using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float walkSpeed = 10f;
    private bool canJump = true;
    private Rigidbody2D rb;

    //Jump king Stuff
    [SerializeField] private bool jumpKingJump = false;
    [SerializeField] private float jumpForce = 0.0f;
    [SerializeField] private float jumpSpeed = 30.0f;
    [SerializeField] private float maxJumpForce = 20.0f;
    private int gravityDefault;
    
    //private Animator anim;
    [SerializeField] private Collider2D feetCollider;
    private SpriteRenderer spriteRenderer;
    private Transform feet;

    //Mario Movement Stuff
    [SerializeField] private float maxJumpHeight = 5f;
    [SerializeField] private float maxJumpTime = 1f;
    [SerializeField] private float mJumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    [SerializeField] private float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);
    [SerializeField] private bool jumping;
    private Vector2 velocity;
    private float inputAxis = 8.0f;

    //private bool grounded;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        feet = transform.Find("Feet");
        //gravityDefault = rb.Gravity
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(jumpKingJump) //If jump king mode is true, use the jump king stuff, otherwise use mario jumping
        {
            if(jumpForce == 0.0f && IsGrounded())
            {
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, rb.velocity.y);
            }

            if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() && canJump)
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }

            if(Input.GetKey(KeyCode.Space) && IsGrounded() && canJump && jumpForce < maxJumpForce)
            {
                jumpForce += jumpSpeed * Time.deltaTime;
            }
        }
        else //Mario Jumping
        {
            //if(Input.GetKey(KeyCode.Space))
            //{
            //    Jump();
            //}
            HorizontalMovement();
            if (IsGrounded())
            {
                GroundedMovement(); 
            }

            ApplyGravity();
        }
        
        if(horizontalInput != 0) spriteRenderer.flipX = horizontalInput < 0f;

        jumpForce = Mathf.Min(jumpForce, maxJumpForce);


        //when space key is released
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(IsGrounded())
            {
                rb.velocity = new Vector2(horizontalInput * walkSpeed, jumpForce);
                jumpForce = 0.0f;
            }
            canJump = true;
        }

        //when space key is released
        if(Input.GetKeyUp(KeyCode.J))
        {
            if(jumpKingJump)
            {
                jumpKingJump = false;

            }
            else
            {
                jumpKingJump = true;
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, walkSpeed);
    }

    private void ResetJump()
    {
        canJump = false;
        jumpForce = 0;
    }

    public bool IsGrounded()
    {
        var hit = Physics2D.BoxCast(feet.position, transform.localScale, 0f, Vector2.down, 0.1f, jumpableGround);
        return hit && hit.point.y <= feet.position.y && feetCollider.IsTouching(hit.collider);
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * walkSpeed, walkSpeed * Time.deltaTime);

        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, rb.velocity.y); OLD
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Jump();
            velocity.y = (mJumpForce);
            jumping = true;
        }
    }

    private void FixedUpdate()
    {
        if(!jumpKingJump)
        {
            Vector2 position = rb.position;
            position += velocity * Time.fixedDeltaTime;

            rb.MovePosition(position);
        }
    }

    private void ApplyGravity ()
    {
        bool falling = velocity.y < 0f || !Input.GetKey(KeyCode.Space);
        float multiplier = falling ? 2f : 1f;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }
}
