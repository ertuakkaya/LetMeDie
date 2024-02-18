using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// this scirpt is responsible for managing the game. such as checking if the game is winnable, checking the portal, etc.

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance { get; set; }
    
    
    public float counter = 5f;
    private BloodController bloodController;


    /// Finish Game
    [SerializeField] public bool isWinnable = false;
    [SerializeField] private ParticleSystem portalEffect;
    [SerializeField] private GameObject winPlatform;
    
   // CollectFlasks.cs'de kullanılıyor. , Toplanan flask sayısını tutar.
    public int flaskCount = 0;
    
    
    // Check if the task is completed
    [SerializeField] public  bool isBoneCollected = false;
    [SerializeField] public  bool isSkullCollected = false;
    [SerializeField] public  bool isFlaskCollected = false;
    [SerializeField] public bool isBloodCollected = false; //
    [SerializeField] public bool isParsementCollected = false; //
     
    
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    { 
        bloodController = BloodController.Instance;
        
        isWinnable = false; // Game is not finished at the beginning.
        portalEffect.Stop(); // Portal effect is not active at the beginning.
    }

    private void Update()
    {
       
        CheckTask();
    }

    private void FixedUpdate()
    {
        PeridocialBloodDecrease();
        if (bloodController.IsFrozen() && bloodController.IsAlive())
        {
            TriggerGameOver();
        }
    }

    private void PeridocialBloodDecrease()
    {
        // {counter} saniyede bir -2 can azalt.
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            bloodController.ChangeBlood(-2);
            counter = 5f;
        }
    }

    public void EndTheLevel()
    {
        var bcon = BloodController.Instance;
        bcon.KillCharacter();
        if (!( bcon.IsAlive() ) && !( bcon.IsFrozen() ) )
        {
            //TODO : Oyunu Kazand�.
            SceneManager.LoadScene("The end 1"); // Load the win scene.
            
        }
    } 
    
   
    // Task check
    private void CheckTask()
    {
        // if all tasks are completed, activate the win platform.
        if (isParsementCollected && isBloodCollected && isFlaskCollected && isSkullCollected && isBoneCollected)
        {
            //Debug.Log( "sadsada" + isBoneCollected  +  isSkullCollected + isFlaskCollected + isParsementCollected);
            //Debug.Log("All tasks are completed.");
            isWinnable = true;
            portalEffect.Play(); // Activate the portal effect.

        }
        
        
    }
    
    public void TriggerGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
