using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float walkSpeed = 10;
    [SerializeField] private bool jumpKingJump = true;
    [SerializeField] private float jumpForce = 0.0f;
    private bool canJump = true;
    private Rigidbody2D rb;
    //private Animator anim;
    private BoxCollider2D collider;
    private PhysicsMaterial2D bounceMat, normalMat;

    //private bool grounded;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        
        
        if(jumpForce == 0.0f && IsGrounded() && jumpKingJump)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, rb.velocity.y);
        } else if(!jumpKingJump)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, rb.velocity.y);
        }
        
        

        //Flip player sprite when moving left or right
        if(horizontalInput >= 0.01f)
        {
            transform.localScale = Vector3.one;
        } else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKey(KeyCode.Space) && IsGrounded() && !jumpKingJump)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() && jumpKingJump && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if(Input.GetKey(KeyCode.Space) && IsGrounded() && jumpKingJump && canJump && jumpForce < 20f)
        {
            jumpForce += 0.1f;
        }

        /*if((jumpForce >= 20.1f) && IsGrounded() && jumpKingJump)
        {
            float tempx = horizontalInput * walkSpeed;
            float tempy = jumpForce;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }
        */

        if(jumpForce >= 0 && !IsGrounded()) 
        {
            rb.sharedMaterial = bounceMat;
        }else
        {
            rb.sharedMaterial = bounceMat;
            //rb.sharedMaterial = normalMat;
        }

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
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, walkSpeed);
        /*float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            jumpForce += 0.5f;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            rb.sharedMaterial = bounceMat;
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if (Input.GetKey(KeyCode.Space) && IsGrounded() && jumpForce >= 20.0f || Input.GetKey(KeyCode.Space) == false && jumpForce >= 0.1f)
        {
            float tempX = horizontalInput * walkSpeed;
            float tempY = jumpForce;
            rb.velocity = new Vector2(tempX,tempY);
            Invoke("ResetJump", 0.025f);  
        }
        if (rb.velocity.y <= -1)
        {
            rb.sharedMaterial = normalMat;
        }
        */
    }

    private void ResetJump()
    {
        canJump = false;
        jumpForce = 0;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
