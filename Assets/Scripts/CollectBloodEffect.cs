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
    }

    // Update is called once per frame
    void Update()
    {
        if (isBloodNear && Input.GetKeyDown(KeyCode.E) && !isBLoodCollected)
        {
            isBLoodCollected = true;

            bloodCollectEffect.Play();

            UnVisFlask();

            bloodHealEffect.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBloodNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBloodNear = false;
        }
    }

    private void UnVisFlask()
    {

        Invoke("StopEffect", 2f);
        CheckTask(); 

    }

    private void CheckTask()
    {
        switch (gameObject.tag)
        {

          
            case "Blood":
                GameManager.Instance.isBloodCollected = true;
                Debug.Log("Blood is collected." + GameManager.Instance.isBloodCollected);
                BloodController.Instance.ChangeBlood(10); // blood is increased by 10
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
