using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int healthDisplay;
    private int scoreDisplay;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay = player.score;
        healthDisplay = player.GetComponent<Health>().health;
        text.SetText("Health: " + healthDisplay + "\nScore: " + scoreDisplay);
    }
}
