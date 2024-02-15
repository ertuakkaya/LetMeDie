using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_menu : MonoBehaviour
{
    public static Main_menu Instance { get; private set; }
    public Canvas SettingsMenuCanvas;
    public Canvas MainMenuCanvas;
    private AudioSource musicSource;

    private void Awake()
    {
        Instance = this;
    }   
    void Start()
    {
        musicSource = FindObjectOfType<AudioSource>();
        // Müzik çalmaya baþla
        musicSource.Play();
    }



    public void PlayButton()
    {
        SceneManager.LoadScene(4);
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
    public void StopMusic()
    {
        // Müziði durdur
        musicSource.Stop();
    }
    public void StartMusic()
    {
        // Müziði tekrar çalmaya baþla
        musicSource.Play();
    }
}
