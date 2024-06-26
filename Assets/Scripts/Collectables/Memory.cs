using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public string text = "";
    public Player playerObj = null;
    private BoxCollider2D playerRB = null;


    [SerializeField] private TextMeshProUGUI alertText;
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
            Player.score++;
            Player.maxJumps = 2;

            alertText.GetComponent<RectTransform>().position = new Vector3(-0.4f, -0.1f, 0);

            Destroy(gameObject);
        }
    }

}
