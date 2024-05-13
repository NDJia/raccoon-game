using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    private Animator anim;

    private GameObject attackArea = default;

    private GameObject attackTriggerArea = default;

    private GameObject RangedAttackTriggerArea = default;

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
        RangedAttackTriggerArea = transform.GetChild(2).gameObject;
        attackSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<enemy>().horizontal != 0)
        {
            horizontal = GetComponent<enemy>().horizontal;
        }

        if (RangedAttackTriggerArea.GetComponent<attackTrigger>().inAttackArea && !attacking)
        {
            Debug.Log("attacking");
            StartCoroutine(attackCountDown());
            RangedAttack();
        }
    }
    IEnumerator attackCountDown()
    {

        yield return new WaitForSeconds(AttackDelay);
        attacking = false;
        projectile.SetActive(false);
        Debug.Log("not attacking");
    }

    private void RangedAttack()
    {
        attacking = true;
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
