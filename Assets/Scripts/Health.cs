using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health=100;
    public int maxHealth=100;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        FlashRed();
    }

    private void Die(){
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }

    private void FlashRed()
    {
        StartCoroutine(FlashRedCoroutine());
    }

    private IEnumerator FlashRedCoroutine()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }
}
