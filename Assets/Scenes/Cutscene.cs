using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{

    [SerializeField] private Image img;
    [SerializeField] private Sprite scene1;
    [SerializeField] private Sprite scene2;
    [SerializeField] private Sprite scene3;
    [SerializeField] private Sprite scene4;
    [SerializeField] private Sprite scene5;
    [SerializeField] private Sprite scene6;
    [SerializeField] private Sprite scene7;

    private AudioSource bgm;

    private int sceneNumber = 1;

    private float timeSinceSceneChange;

    // Start is called before the first frame update
    void Start()
    {
        img.sprite = scene1;
        timeSinceSceneChange = Time.time;
        //bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeSinceSceneChange > 2f)
        {
            timeSinceSceneChange = Time.time;
            sceneNumber++;
            switch(sceneNumber)
            {
                case 2:
                    img.sprite = scene2;
                    break;
                case 3:
                    img.sprite = scene3;
                    break;
                case 4:
                    img.sprite = scene4;
                    break;
                case 5:
                    img.sprite = scene5;
                    break;
                case 6:
                    img.sprite = scene6;
                    break;
                case 7:
                    img.sprite = scene7;
                    break;
                default:
                    SceneManager.LoadScene("AlleywayS");
                    break;
            }
        }
    }
}
