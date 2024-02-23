using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour { 

    float directionX;
    public float walkSpeed = 4f;
    

    // ground
    bool isGround;
    float ratioFoot = .5f;

    // jump
    bool canJump = true;
    float jumpValue = .0f;

    // components player
    Rigidbody2D rb;

    public Transform foot;
    public LayerMask groundMask;
    public PhysicsMaterial2D player_bounce, player_mat;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        directionX = Input.GetAxis("Horizontal");


        isGround = Physics2D.OverlapCircle(foot.position, ratioFoot, groundMask);

        if (jumpValue == .0f && isGround)
        {
            rb.velocity = new Vector2(directionX * walkSpeed, rb.velocity.y);
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
        }

        if (Input.GetKeyDown(KeyCode.W) && isGround && canJump)
        {
            rb.velocity = new Vector2(.0f, rb.velocity.y);
        }

        if (jumpValue >= 15f && isGround)
        {
            float tempX = directionX * walkSpeed;
            float tempY = jumpValue;

            rb.velocity = new Vector2(tempX, tempY);

            Invoke("ResetJump", .2f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (isGround)
            {
                rb.velocity = new Vector2(directionX * walkSpeed, jumpValue);
                jumpValue = .0f;
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