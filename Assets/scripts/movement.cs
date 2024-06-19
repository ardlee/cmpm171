using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using Unity.VisualScripting;
public class movement : MonoBehaviour
{

    public float directionX;
    public float walkSpeed = 4f;

    public Image jumpFillImage;

    // ground
    bool isGround;
    float ratioFoot = .55f;

    // jump
    bool canJump = true;
    float jumpValue = .0f;

    // components player
    public Rigidbody2D rb;
    private Animator animator;

    public Transform foot;
    public LayerMask groundMask;
    public PhysicsMaterial2D player_bounce, player_mat;

    // audio
    private EventInstance playerFootsteps;
    private EventInstance charge;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool knockFromRight;
    public int knockbackCount = 0;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
        charge = AudioManager.instance.CreateInstance(FMODEvents.instance.charge);
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
        if (KBCounter <= 0)
        {
            if (jumpValue == .0f && isGround)
            {
                rb.velocity = new Vector2(directionX * walkSpeed, rb.velocity.y);
                animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
            }
        }
        else
        {
            if (knockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (knockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
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
            jumpValue += .66f;
            jumpFillImage.fillAmount = jumpValue / 15f;
        }

        if (Input.GetKeyDown(KeyCode.W) && isGround && canJump)
        {
            rb.velocity = new Vector2(.0f, rb.velocity.y);
            animator.SetFloat("ChargeLevel", jumpValue);
            animator.SetBool("isJumping", true);
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
                animator.SetBool("isJumping", false);
            }
            canJump = true;
        }

        UpdateSound();

    }
    private void UpdateSound()
    {
        // start footsteps event if the player has an x velocity and is on the ground
        if (rb.velocity.x != 0 && isGround && !Input.GetKey(KeyCode.W))
        {
            // get the playback state
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
            float volume = 0.2f;
            playerFootsteps.setVolume(volume);
        }
        // otherwise, stop the footsteps event
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }

        if (Input.GetKey(KeyCode.W) && isGround)
        {
            PLAYBACK_STATE chargePlaybackState;
            charge.getPlaybackState(out chargePlaybackState);
            if (chargePlaybackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                charge.start();
            }
            float volume = 0.2f;
            charge.setVolume(volume);
        }
        else
        {
            charge.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

}