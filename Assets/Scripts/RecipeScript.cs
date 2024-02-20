using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RecipeScript : MonoBehaviour
{
    // singleton
    
    public static RecipeScript Instance { get; private set; }
    
    
    
    
    public GameObject RecipePaper;
    public Canvas MissionCanvas;
    private bool NesneToplandi=false;
    private bool CanvasAcik=false;
    
    // Task TMP
    public TextMeshProUGUI taskText1;
    public TextMeshProUGUI taskText2;
    public TextMeshProUGUI taskText3;
    public TextMeshProUGUI taskText4;
    
    
    // Mission Paper 
    [SerializeField] private bool isMissionPaperCollected = false;
    
    
    // Book
    [SerializeField] private GameObject recipeBook;
    
    
    // Dilara
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==RecipePaper &&  !NesneToplandi) 
        { 
            NesneToplandi = true;

            MissionCanvas.enabled = true;
        }
        
    }
    */
    /// //////////////
    private void Awake()
    {
        // Singleton
        Instance = this;
    }


    private void Start()
    {
        MissionCanvas.enabled = false;
        
        recipeBook.SetActive(false);// at the beginning, don't show book
    }


    private void Update()
    {
        // Dilara
        /*
        if(NesneToplandi) 
        {
            if(Input.GetKeyDown(KeyCode.F)) 
            {
                if (!CanvasAcik)
                {
                    MissionCanvas.enabled=true;
                }
                else
                {
                    MissionCanvas.enabled=false;
                }
                
            }
        }
        */
        //////////////////////////////////////////
        
        MissionCanvasControl();
        
    }

    private void MissionCanvasControl()
    {
        if (!GameManager.Instance.isParsementCollected)
        {
            MissionCanvas.enabled = false;
            CanvasAcik = false;
            recipeBook.SetActive(false);
        }
        
        // if canvas is not active, when player press F, canvas will be active
        else if (Input.GetKeyDown(KeyCode.F) && !CanvasAcik ) // if  F key is pressed and canvas is not active
        {
            MissionCanvas.enabled = true;
            CanvasAcik = true;
            recipeBook.SetActive(true);
            
        }
        else if (Input.GetKeyDown(KeyCode.F ) && CanvasAcik) // if F key is pressed and canvas is active
        {
            CanvasAcik = false;
            MissionCanvas.enabled = false;
            recipeBook.SetActive(false);
        }
    }
    
}
