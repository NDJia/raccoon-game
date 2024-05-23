using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [SerializeField] private Button infoBox;

    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void enterInfoBox()
    {
        infoBox.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
    }

    public void exitInfoBox()
    {
        infoBox.GetComponent<RectTransform>().position = new Vector3(2000, 2000, 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
