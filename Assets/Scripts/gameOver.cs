using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{

    [SerializeField] private Player player;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Raccoon")==null)
        {
            transform.position = new Vector3(0f, 1f, 0f);
        }
        

    }
}
