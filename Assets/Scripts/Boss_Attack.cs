using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    private Animator anim;

    private GameObject attackArea = default;

    private GameObject attackTriggerArea = default;

    private GameObject meleeTriggerArea = default;

    public GameObject projectile;

    private bool attacking = false;

    public float timeToAttack = 1f;

    public float AttackDelay = 0.5f;

    private float timer = 0f;

    private AudioSource attackSound;

    private bool meleeAttack;

    public float horizontal = 0f;

    private GameObject playerObj = null;

    // Start is called before the first frame update
    void Start()
    {
        if (projectile != null)
        {
            //Debug.Log("projectile found");
        }
        attackArea = transform.GetChild(0).gameObject;
        attackTriggerArea = transform.GetChild(1).gameObject;
        meleeTriggerArea = transform.GetChild(2).gameObject;
        playerObj = GameObject.Find("Raccoon");
        attackSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Debug.Log("attack loaded");
    }

    public bool ifAttacking()

    {

        return attacking;

    }



    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Boss>().horizontal != 0)
        {
            horizontal = GetComponent<Boss>().horizontal;
        }

        //Debug.Log(attacking);
        if (attackTriggerArea.GetComponent<attackTrigger>().inAttackArea && !attacking)
        {
            attacking = true;
            Debug.Log("long range attacking");
            StartCoroutine(attackCountDown());
            Attack();

        }

        if (Math.Abs(playerObj.transform.position.x - this.transform.position.x) < 1.5)
        {
            Debug.Log("melee attacking");
            melee();
        }
    }
    IEnumerator attackCountDown()
    {

        yield return new WaitForSeconds(timeToAttack);

        projectile.SetActive(false);
        attacking = false;
        Debug.Log("not attacking");
    }

    private void Attack()
    {

        //StartCoroutine("DelayAttack");
        projectile.GetComponent<BossProjectile>().Launch();
        attackSound.Play();

        // Flip the attack area based on the player's facing direction
        if (transform.localScale.x > 0) // Player facing right
        {
            attackArea.transform.localScale = new Vector3(0.5f, 1f, 0f); // Maintain the dimensions
        }
        else if (transform.localScale.x < 0) // Player facing left
        {
            attackArea.transform.localScale = new Vector3(-0.5f, 1f, 0f); // Flip and maintain the dimensions
        }
        anim.SetTrigger("rangedAttack");
    }

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(AttackDelay);
        attackArea.SetActive(true);
        anim.SetTrigger("meleeAttack");
    }

    private void melee()
    {
        attacking = true;
        StartCoroutine("DelayAttack");
        attackSound.Play();

        // Flip the attack area based on the player's facing direction
        if (transform.localScale.x > 0) // Player facing right
        {
            attackArea.transform.localScale = new Vector3(0.5f, 1f, 0f); // Maintain the dimensions
        }
        else if (transform.localScale.x < 0) // Player facing left
        {
            attackArea.transform.localScale = new Vector3(-0.5f, 1f, 0f); // Flip and maintain the dimensions
        }
        
    }
}
