using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBloodEffect : MonoBehaviour
{
    public static CollectBloodEffect Instance { get; private set; }

    [SerializeField] public bool isBloodNear = false;
    [SerializeField] private bool isBLoodCollected = false;
    [SerializeField] public ParticleSystem bloodCollectEffect;
    [SerializeField] public ParticleSystem bloodHealEffect;


    private void Awake()
    {
        // singleton pattern
        Instance = this;
    }

    void Start()
    {
        
        bloodCollectEffect.Stop();
        CollectLantern.Instance.lanternCanvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBloodNear && Input.GetKeyDown(KeyCode.E) && !isBLoodCollected)
        {
            isBLoodCollected = true;

            bloodCollectEffect.Play();
            
            Invoke("StopEffect", 2f); // stop the effect after 2 seconds
            
            CheckTask();  ///
            
            bloodHealEffect.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isBLoodCollected)
        {
            isBloodNear = true;
            CollectLantern.Instance.lanternCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBloodNear = false;
            CollectLantern.Instance.lanternCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
    
    private void CheckTask()
    {
        switch (gameObject.tag)
        {

          
            case "Blood":
                isBLoodCollected = true;
                GameManager.Instance.isBloodCollected = true;
                //Debug.Log("Blood is collected." + GameManager.Instance.isBloodCollected);
                BloodController.Instance.ChangeBlood(10); // blood is increased by 10
                AudioScriptMain.Instance.musicSource.PlayOneShot(AudioScriptMain.Instance.bloodDrinkSound); // play blood drink sound
                break;

            default:
                // Optional: Handle any other cases here

                break;
        }

    }
    private void StopEffect()
    {
        bloodCollectEffect.Stop();
    }
}
