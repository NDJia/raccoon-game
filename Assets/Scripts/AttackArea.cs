using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage=50;
    public GameObject attackArea = default;
    public float attackWindow = 0.1f;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        Debug.Log("attacking");
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            Debug.Log("hit");
        }
        StartCoroutine("DelayAttack");
    }
    IEnumerator DelayAttack()
    {

        yield return new WaitForSeconds(attackWindow);
        attackArea.SetActive(false);
    }
}
