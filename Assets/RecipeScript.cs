using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeScript : MonoBehaviour
{
    public GameObject RecipePaper;
    public Canvas MissionCanvas;
    private bool NesneTopland�=false;
    private bool CanvasA��k=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==RecipePaper &&  !NesneTopland� ) 
        { 
            NesneTopland� = true;

            MissionCanvas.enabled = true;
        }
        
    }
    private void Update()
    {
        if(NesneTopland�) 
        {
            if(Input.GetKeyDown(KeyCode.F)) 
            {
                if (!CanvasA��k)
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
