using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    public Animator animatior;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject attackArea;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animatior.SetFloat("Speed",Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
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
            transform.localScale = new Vector3(0.08f, 0.08f, 0.08f); // Player facing right
            //attackArea.transform.localScale = new Vector3(0.5f, 1f, 0f);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-0.08f, 0.08f, 0.08f); // Player facing left
            //ttackArea.transform.localScale = new Vector3(-0.5f, 1f, 0f);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}

