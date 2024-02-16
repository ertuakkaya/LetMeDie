using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeScript : MonoBehaviour
{
    public GameObject RecipePaper;
    public Canvas MissionCanvas;
    private bool NesneToplandý=false;
    private bool CanvasAçýk=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==RecipePaper &&  !NesneToplandý ) 
        { 
            NesneToplandý = true;

            MissionCanvas.enabled = true;
        }
        
    }
    private void Update()
    {
        if(NesneToplandý==true) 
        {
            if(Input.GetKeyDown(KeyCode.F)) 
            {
                if (CanvasAçýk==false)
                {
                    MissionCanvas.enabled=true;
                }
                else
                {
                    MissionCanvas.enabled=false;
                }
                
            }
        }
    }
}
