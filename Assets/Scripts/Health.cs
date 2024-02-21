using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health=100;
    public int maxHealth=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // if(Input.GetKeyDown(KeyCode.J)){
        //     Damage(10);
        // }   
    }
    public void Damage(int damage){
        this.health-=damage;
        if(health>maxHealth){
            health=maxHealth;
        }
        if(health<=0){
            Die();
        }
    }

    private void Die(){
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}
