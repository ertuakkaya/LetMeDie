using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptMain : MonoBehaviour
{
    private AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = FindObjectOfType<AudioSource>();
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
