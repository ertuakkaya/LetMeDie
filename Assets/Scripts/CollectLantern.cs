using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLantern : MonoBehaviour
{
    
    // when player is near the lantern, show the canvas
    // when player press E, collect the lantern and destroy it
    
    
    [SerializeField] private bool isLanterCollected = false;
    [SerializeField] private bool isLanterNear = false;
    public Canvas lanternCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        lanternCanvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void CheckPlayerNear()
    {
        if (isLanterNear)
        {
            lanternCanvas.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            lanternCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //if (!other.gameObject.CompareTag("Player") ) 
        
        if (other.gameObject.CompareTag("Player"))
        {
            lanternCanvas.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && !isLanterCollected)
            {
                isLanterCollected = true;
                lanternCanvas.GetComponent<Canvas>().enabled = false;
                //Destroy(gameObject); //lantern is collected and destroyed 
            }
            
        }
        else
        {
            lanternCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
