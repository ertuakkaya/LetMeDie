using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is for the lantern that player can collect

public class CollectLantern : MonoBehaviour
{
    public static CollectLantern Instance { get; private set; }
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sideLantern;
    [SerializeField] private Light lightTop;
    [SerializeField] public ParticleSystem lanterFlameEffect;
    
    // when player is near the lantern, show the canvas
    // when player press E, collect the lantern and destroy it
    
    
    
    [SerializeField] public bool isLanterCollected = false;
    [SerializeField] public bool isLanterNear = false;
    public Canvas lanternCanvas;
    [SerializeField] public bool showCanvas = false;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lanterFlameEffect.Stop();
        player.GetComponent<Light>().enabled = false;
        lanternCanvas.GetComponent<Canvas>().enabled = false;
        lightTop.GetComponent<Light>().enabled = false;
        
        
        sideLantern.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //LanternIntensity(); // lantern intensity is changing over time when it is collected // it is not working properly
        
        LanternIntensity();

        if (isLanterNear && Input.GetKeyDown(KeyCode.E) && !isLanterCollected)
        {
            isLanterCollected = true;
            CheckLanterCollected();
            lanternCanvas.GetComponent<Canvas>().enabled = false;
            UnVisLantern();
            lanterFlameEffect.Play();
            sideLantern.SetActive(true);
        }
        
        
    }
    
    
    
    private void CheckLanterCollected()
    {
        if (!isLanterCollected) return;
        player.GetComponent<Light>().enabled = true;
        isLanterCollected = true;
        lightTop.GetComponent<Light>().enabled = true;
        //Debug.Log("Lantern is collected and added to the player's light component.");
        
       
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lanternCanvas.GetComponent<Canvas>().enabled = true;
            showCanvas = true;
            isLanterNear = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lanternCanvas.GetComponent<Canvas>().enabled = false;
            showCanvas = false;
            isLanterNear = false;
        }
    }

    private void UnVisLantern()
    {
        // works
        // it is getting the children of the lantern and disabling them
        gameObject.GetComponent<BoxCollider>().enabled = false; // lanter collider is disabled
        gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false; // lantern mesh is disabled
        gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false; // candle mesh is disabled
        gameObject.transform.GetChild(2).gameObject.GetComponent<Light>().enabled = false; // light is disabled
       
        
    }
    
    private void LanternIntensity()
    {
        if (!isLanterCollected) return;
        player.GetComponent<Light>().intensity = Mathf.PingPong(Time.time,13);
    }
    
    
    
}
