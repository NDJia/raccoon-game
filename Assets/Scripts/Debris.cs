using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage(int damage)
    {
        this.health -= damage;
        
        if (health <= 0 )
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Debug.Log("Blockade destroyed!");
        Destroy(gameObject);
    }
}
