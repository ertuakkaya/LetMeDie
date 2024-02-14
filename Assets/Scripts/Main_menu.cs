using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public Canvas SettingsMenuCanvas;
    public Canvas MainMenuCanvas;
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton() 
    {
        SettingsMenuCanvas.GetComponent<Canvas>().enabled = true;
        MainMenuCanvas.GetComponent<Canvas>().enabled = false;
    }
    public void BackButton()
    {
        MainMenuCanvas.GetComponent<Canvas>().enabled = true;
        SettingsMenuCanvas.GetComponent<Canvas>().enabled = false;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
