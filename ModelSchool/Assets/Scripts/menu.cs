using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject menuObj;
    public string sceneName;
    public Button playButton;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Go to play scene
    public void playGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }


    //close application
    public void quitGame()
    {
        Application.Quit();
    }

    //from settings go to menu 
    public void backToMenu()
    {
        menuObj.SetActive(true);
    }
}