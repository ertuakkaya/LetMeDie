using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLantern : MonoBehaviour
{
    
    [SerializeField] private bool isLanterCollected = false;
    public Canvas lanternCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        lanternCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lanternCanvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && !isLanterCollected)
            {
                isLanterCollected = true;
                lanternCanvas.gameObject.SetActive(false);
                Destroy(gameObject); //lantern is collected and destroyed 
            }
            
        }
    }
}
