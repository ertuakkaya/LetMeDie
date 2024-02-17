using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFlasks : MonoBehaviour
{
    
    // singleton
    public static CollectFlasks Instance { get; private set; }



    [SerializeField] private GameObject player;
    [SerializeField] private GameObject flask1;
    [SerializeField] public bool isFlask1Near = false;
    [SerializeField] private bool isFlask1Collected = false;
    [SerializeField] public ParticleSystem collectEffect;

    
    //
    [SerializeField] private bool isBoneCollected = false;
    [SerializeField] private bool isSkullCollected = false;
    
    
    private void Awake()
    {
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
            
            Debug.Log("Flask 1 is collected   :    " + GameManager.Instance.flaskCount);

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
        //gameObject.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false; // candle mesh is disabled
        //gameObject.transform.GetChild(2).gameObject.GetComponent<Light>().enabled = false; // light is disabled
        
        Invoke("StopEffect",0.5f);
        
        /*
        if (gameObject.CompareTag("Bone"))
        {
            isBoneCollected = true;
            Debug.Log("Bone is collected.");
        }
        */
        
        CheckTask();
        
        
    }

    
    
    // Task check
    private void CheckTask()
    {
        switch (gameObject.tag)
        {
            case "Bone":
                isBoneCollected = true;
                Debug.Log("Bone is collected.");
                break;

            case "Skull":
                isSkullCollected = true;
                Debug.Log("Skull is collected.");
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
