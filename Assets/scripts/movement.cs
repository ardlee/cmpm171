using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movement : MonoBehaviour { 

    public float directionX;
    public float walkSpeed = 4f;
    
    public Image jumpFillImage;

    // ground
    bool isGround;
    float ratioFoot = .5f;

    // jump
    bool canJump = true;
    float jumpValue = .0f;

    // components player
    public Rigidbody2D rb;
    private Animator animator;

    public Transform foot;
    public LayerMask groundMask;
    public PhysicsMaterial2D player_bounce, player_mat;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        // Store the current local scale
        Vector3 currentScale = transform.localScale;

        // Flip the sprite if moving left
        if (directionX < 0 && currentScale.x > 0 && isGround)
        {
            transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
        }
        // Flip the sprite if moving right
        else if (directionX > 0 && currentScale.x < 0 && isGround)
        {
            transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
        }


        isGround = Physics2D.OverlapCircle(foot.position, ratioFoot, groundMask);

        if (jumpValue == .0f && isGround)
        {
            rb.velocity = new Vector2(directionX * walkSpeed, rb.velocity.y);
            animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        }

        if (!isGround)
        {
            jumpValue = .0f;
            jumpFillImage.fillAmount = .0f;
        }

        if (jumpValue > 0)
        {
            rb.sharedMaterial = player_bounce;
        }
        else
        {
            rb.sharedMaterial = player_mat;
        }

        if (Input.GetKey(KeyCode.W) && isGround && canJump)
        {
            jumpValue += .06f;
            jumpFillImage.fillAmount = jumpValue / 15f;
        }

        if (Input.GetKeyDown(KeyCode.W) && isGround && canJump)
        {
            rb.velocity = new Vector2(.0f, rb.velocity.y);
        }

        if (jumpValue >= 15f && isGround)
        {
            jumpValue = 15f;
            //float tempX = directionX * walkSpeed;
            //float tempY = jumpValue;

            //rb.velocity = new Vector2(tempX, tempY);

            //Invoke("ResetJump", .2f);
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            if (isGround)
            {
                rb.velocity = new Vector2(directionX * walkSpeed, jumpValue);
                jumpValue = .0f;
                jumpFillImage.fillAmount = 0f;
            }
            canJump = true;
        }
    }

    private void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
}