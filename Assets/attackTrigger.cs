using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public bool enterAttackArea = false;
    public bool inAttackArea = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        enterAttackArea = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        inAttackArea = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        enterAttackArea = false;
    }
}
