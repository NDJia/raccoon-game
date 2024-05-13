using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Attack : MonoBehaviour
{
    private Animator anim;

    private GameObject attackArea = default;

    private GameObject attackTriggerArea = default;

    public GameObject projectile;

    private bool attacking = false;

    public float timeToAttack = 1f;

    public float AttackDelay = 0.5f;

    private float timer = 0f;

    private AudioSource attackSound;

    public float horizontal = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (projectile != null)
        {
            //Debug.Log("projectile found");
        }
        attackArea = transform.GetChild(0).gameObject;
        attackTriggerArea = transform.GetChild(1).gameObject;
        attackSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Debug.Log("attack loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<RangedEnemy>().horizontal!=0)
        {
            horizontal = GetComponent<RangedEnemy>().horizontal;
        }
        Debug.Log(attacking);
        if (attackTriggerArea.GetComponent<attackTrigger>().inAttackArea && !attacking)
        {
            attacking = true;
            Debug.Log("attacking");
            StartCoroutine(attackCountDown());
            Attack();

        }
    }
    IEnumerator attackCountDown()
    {

        yield return new WaitForSeconds(AttackDelay);
        
        projectile.SetActive(false);
        attacking = true;
        Debug.Log("not attacking");
    }

    private void Attack()
    {
        
        //StartCoroutine("DelayAttack");
        projectile.GetComponent<EnemyProjectile>().Launch();
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

}
