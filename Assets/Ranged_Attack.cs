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

    public float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        if (projectile != null)
        {
            Debug.Log("projectile found");
        }
        attackArea = transform.GetChild(0).gameObject;
        attackTriggerArea = transform.GetChild(1).gameObject;
        attackSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = GetComponent<enemy>().horizontal;
        if (attackTriggerArea.GetComponent<attackTrigger>().enterAttackArea)
        {
            Debug.Log("attacking");

            Attack();
        }

        if (attacking)
        {
            StartCoroutine(Delay());
                
               
            
        }
    }
    IEnumerator Delay()
    {

        yield return new WaitForSeconds(AttackDelay);
        attacking = false;
        Debug.Log("not attacking");
    }

    private void Attack()
    {
        attacking = true;
        //StartCoroutine("DelayAttack");
        projectile.SetActive(attacking);
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
