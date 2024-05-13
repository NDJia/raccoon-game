using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public int damage=50;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("attacking");
        if (collider.GetComponent<Health>() != null)
        {
            Debug.Log("hit");
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
