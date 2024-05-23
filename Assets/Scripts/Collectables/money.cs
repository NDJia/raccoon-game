using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{

    public int value = 1;
    public Player playerObj = null;
    private BoxCollider2D playerRB = null;


    [SerializeField] private BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = FindObjectOfType<Player>();
        }

        playerRB = playerObj.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.IsTouching(hitbox, playerRB))
        {
            playerObj.score++;
            Destroy(gameObject);
        }
    }
}
