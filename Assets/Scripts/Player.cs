using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxJumps = 1; // this value is edited at double jump location.
    public int jumps = 1;
    private float timeLeftGround = 0f;

    public float charScale = 0.2f;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    public Animator animatior;

    public int score = 0;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject attackArea;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        //print(jumps + " " + maxJumps);
        horizontal = Input.GetAxisRaw("Horizontal");
        animatior.SetFloat("Speed", Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            if ((IsGrounded() && Time.time - timeLeftGround > 0.1f))
            {
                timeLeftGround = Time.time; 
            }

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animatior.SetTrigger("Jump");
            --jumps;

        }

        if (!Input.GetButtonDown("Jump") && IsGrounded() && Time.time - timeLeftGround > 0.5f)
        {
            jumps = maxJumps;
        }


        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Check the direction and flip the sprite accordingly while maintaining the scale
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(charScale, charScale, charScale); // Player facing right
            //attackArea.transform.localScale = new Vector3(0.5f, 1f, 0f);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1 * charScale, charScale, charScale); // Player facing left
            //ttackArea.transform.localScale = new Vector3(-0.5f, 1f, 0f);
        }

    }

    private bool IsGrounded()
    {
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return rb.IsTouchingLayers(groundLayer);
    }

}

