using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptMain : MonoBehaviour
{
    // Singleton
    public static AudioScriptMain Instance { get; private set; }
    
    public AudioSource musicSource;
    
    // Collect Audio Source
    public AudioSource CollectAudioSource;
    public AudioClip collectParsementSound;  // Item Collect Audio
    public AudioClip bloodDrinkSound;  // Blood Drink Audio
    
    
    // End Gate (Portal) Audio Source
    public AudioSource PortalSoundAudioSource;
    public AudioClip portalSound;  // End Gate Audio

    
    // Dash Audio Source
    public AudioSource DashAudioSource;
    public AudioClip dashSound;  // Dash Audio
    
    
    // Lantern Collect Audio
    public AudioSource LanternCollectAudioSource;
    public AudioClip lanternCollectSound;  // Lantern Collect Audio
    
    
    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        
    }


    void Start()
    {
        musicSource = FindObjectOfType<AudioSource>();
        musicSource.Play();
        
        
       
    }

    
}
