using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim;

    private GameObject attackArea = default;

    private GameObject attackTriggerArea = default;

    private bool attacking = false;

    public float timeToAttack = 1f;

    public float AttackDelay = 0.5f;

    private float timer = 0f;

    private AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackTriggerArea = transform.GetChild(1).gameObject;
        attackArea.SetActive(attacking);
        attackSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (attackTriggerArea.GetComponent<attackTrigger>().enterAttackArea &&!attacking)
        {
            Debug.Log("attacking");

            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                
                attackArea.SetActive(attacking);
                anim.SetTrigger("meleeAttack");
                Debug.Log("not attacking");
            }
        }
    }
    IEnumerator DelayAttack()
    {
            yield return new WaitForSeconds(AttackDelay);
            attackArea.SetActive(attacking);

    }

    private void Attack()
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
        anim.SetTrigger("meleeAttack");
    }

}
