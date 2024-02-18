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
    
    // Parsement Collect Audio
    public AudioClip collectParsementSound;
    

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
