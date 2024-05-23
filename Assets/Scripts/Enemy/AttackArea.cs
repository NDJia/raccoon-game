using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage=50;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("attacking");
        if (collider.GetComponent<PlayerHealth>() != null)
        {
            Debug.Log("player hit");
            PlayerHealth health = collider.GetComponent<PlayerHealth>();
            health.Damage(damage);
        }

        else if (collider.GetComponent<Health>() != null)
        {
            Debug.Log("enemy hit");
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }

}
