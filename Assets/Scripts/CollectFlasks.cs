using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// This script is for collecting task items such as bone, skull, flask etc.

public class CollectFlasks : MonoBehaviour
{
    
    // singleton pattern
    public static CollectFlasks Instance { get; private set; }



    //[SerializeField] private GameObject player;
    //[SerializeField] private GameObject flask1;
    [SerializeField] public bool isFlask1Near = false;
    [SerializeField] private bool isFlask1Collected = false;
    [SerializeField] public ParticleSystem collectEffect;

    
    private void Awake()
    {
        // singleton pattern
        Instance = this;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        collectEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlask1Near && Input.GetKeyDown(KeyCode.E) && !isFlask1Collected)
        {
            isFlask1Collected = true;
            GameManager.Instance.flaskCount++; // flask count is increased
            
            //Debug.Log("Flask 1 is collected   :    " + GameManager.Instance.flaskCount);

            collectEffect.Play();

            CollectLantern.Instance.lanternCanvas.GetComponent<Canvas>().enabled = false;
            UnVisFlask();

            

        }

    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectLantern.Instance.lanternCanvas.GetComponent<Canvas>().enabled = true;
            CollectLantern.Instance.showCanvas = true;
            isFlask1Near = true;
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectLantern.Instance.lanternCanvas.GetComponent<Canvas>().enabled = false;
            CollectLantern.Instance.showCanvas = false;
            isFlask1Near = false;
            
            
        }
    }
    
    private void UnVisFlask()
    {
        // works
        // it is getting the children of the lantern and disabling them
        gameObject.GetComponent<BoxCollider>().enabled = false; // lanter collider is disabled
        gameObject.GetComponent<MeshRenderer>().enabled = false; // lantern mesh is disabled
        
        Invoke("StopEffect",0.5f); // stop the effect after 0.5 seconds
        CheckTask(); // check if the task is completed
        
         
        
        
    }

    
    
    // Task check
    private void CheckTask()
    {
        switch (gameObject.tag)
        {
            
            case "Bone":
                AudioScriptMain.Instance.musicSource.PlayOneShot(AudioScriptMain.Instance.collectParsementSound); // Play collect sound
                GameManager.Instance.isBoneCollected = true;
                //Debug.Log( "Bone is collected." + GameManager.Instance.isBoneCollected);
                RecipeScript.Instance.taskText1.fontStyle = FontStyles.Strikethrough;
                break;

            case "Skull":
                AudioScriptMain.Instance.musicSource.PlayOneShot(AudioScriptMain.Instance.collectParsementSound); // Play collect sound
                GameManager.Instance.isSkullCollected = true;
                //Debug.Log( "Skull is collected." + GameManager.Instance.isSkullCollected);
                RecipeScript.Instance.taskText2.fontStyle = FontStyles.Strikethrough;
                break;
            
            case "Flask":
                AudioScriptMain.Instance.musicSource.PlayOneShot(AudioScriptMain.Instance.collectParsementSound); // Play collect sound
                GameManager.Instance.isFlaskCollected = true;
                //Debug.Log("Flask is collected." + GameManager.Instance.isFlaskCollected);
                RecipeScript.Instance.taskText3.fontStyle = FontStyles.Strikethrough;
                break;
            case "Parsement":
                AudioScriptMain.Instance.musicSource.PlayOneShot(AudioScriptMain.Instance.collectParsementSound); // Play collect sound
                GameManager.Instance.isParsementCollected = true;
                //Debug.Log("Parsement is collected." + GameManager.Instance.isParsementCollected);
                RecipeScript.Instance.taskText4.fontStyle = FontStyles.Strikethrough;
                break;
            
            // Blood collect is handlin in CollectBloodEffect.cs script . this code is not necessary
            case "Blood":
                GameManager.Instance.isBloodCollected = true;
                //Debug.Log("Blood is collected." + GameManager.Instance.isBloodCollected);
                BloodController.Instance.ChangeBlood(10); // blood is increased by 10
                break;
            
            default:
                // Optional: Handle any other cases here
                break;
        }
        
    }
    
    
   private void StopEffect()
    {
            collectEffect.Stop();
    }
    
    
}
