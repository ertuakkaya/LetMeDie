using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is for the side lantern but it is not used in the game
// ibrahim ayni isi yapan scripti zaten yazmis
public class SideLanternManager : MonoBehaviour
{
    
    // Singleton
    public static SideLanternManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // disable the side lantern at the beginning
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        
        gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false; // lantern mesh is disabled
        gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false; // candle mesh is disabled
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CheckSideLantern()
    {
        if (!CollectLantern.Instance.isLanterCollected) return; // if lantern is not collected, return
        
        // if lantern is collected, enable the side lantern
        
        //gameObject.GetComponent<MeshRenderer>().enabled = true;
        
        gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true; // lantern mesh is disabled
        gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true; // candle mesh is disabled
        //gameObject.transform.GetChild(2).gameObject.GetComponent<Light>().enabled = false; // light is disabled

        


    }
}
