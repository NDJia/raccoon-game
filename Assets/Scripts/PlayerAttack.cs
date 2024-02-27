using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    
    private bool attacking = false;
    
    public float timeToAttack = 0.25f;

    private float timer = 0f;

    private AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
        attackArea.SetActive(attacking);
        attackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("attacking");
            Attack();
        }

        if (attacking){
            timer+=Time.deltaTime;
            if(timer>=timeToAttack){
                timer=0;
                attacking=false;
                attackArea.SetActive(attacking);
                Debug.Log("not attacking");
            }
        }
    }

    private void Attack(){
        attacking = true;
        attackArea.SetActive(attacking);
        attackSound.Play();
    }
}
