using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D mPlayer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleMsg();
    }

    void handleMsg(){
        float horizontalMove = Input.GetAxis("Horizontal");
        if(mPlayer!=null){
            mPlayer.velocity = new Vector2(speed*horizontalMove,mPlayer.velocity.y);
        }
    }
}
