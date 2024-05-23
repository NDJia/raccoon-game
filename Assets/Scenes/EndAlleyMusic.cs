using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAlleyMusic : MonoBehaviour
{

    public Music bgm = null;

    // Start is called before the first frame update
    void Start()
    {
        bgm = FindObjectOfType<Music>();
        if (bgm != null) bgm.EndMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
