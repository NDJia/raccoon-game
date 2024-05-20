using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float spriteSize = 0.5f;
    public float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public Animator animatior;
    public float attackDistance = 1f;
    private GameObject playerObj = null;
    private bool wake = false;
    public float wakeRange = 3;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject attackArea;

    private void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Raccoon");
    }

        void Update()
    {
        if (wakeRange > Math.Sqrt(Math.Pow(this.transform.position.x,2)+ Math.Pow(this.transform.position.y,2)))
        {
            wake = true;
        }
        else if (GameObject.Find("Raccoon") !=null)
        {
            wake = false;
        }
        if (wake)
        {
            if(playerObj.transform.position.x < this.transform.position.x && Mathf.Abs(playerObj.transform.position.x - this.transform.position.x)> attackDistance && !GetComponent<EnemyAttack>().attacking)
            {
                horizontal = -1;
                animatior.SetTrigger("moving");
            }
            else if (playerObj.transform.position.x > this.transform.position.x && Mathf.Abs(playerObj.transform.position.x - this.transform.position.x) > attackDistance && !GetComponent<EnemyAttack>().attacking)
            {
                horizontal = 1;
                animatior.SetTrigger("moving");
            }
            else
            {
                horizontal = 0;
                animatior.ResetTrigger("moving");
            }
            // horizontal = Input.GetAxisRaw("Horizontal");
            // animatior.SetFloat("Speed", Mathf.Abs(horizontal));


            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Check the direction and flip the sprite accordingly while maintaining the scale
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(spriteSize, spriteSize, spriteSize); // Player facing right
            //attackArea.transform.localScale = new Vector3(0.5f, 1f, 0f);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-spriteSize, spriteSize, spriteSize); // Player facing left
            //ttackArea.transform.localScale = new Vector3(-0.5f, 1f, 0f);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}

