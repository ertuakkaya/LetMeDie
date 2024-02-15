using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    
    
    
    public float counter = 5f;
    private BloodController bloodController;


    /// Finish Game
    [SerializeField] private bool isWinnable = false;
    [SerializeField] private ParticleSystem portalEffect;
    [SerializeField] private GameObject winPlatform;
    
   
    
    private void Start()
    { 
        bloodController = BloodController.Instance;
        
        isWinnable = false; // Game is not finished at the beginning.
        portalEffect.Stop(); // Portal effect is not active at the beginning.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // T tusuna basınca portal effecti aktif oluyor.
        {
            CheckPortal();
        }
    }

    private void FixedUpdate()
    {
        PeridocialBloodDecrease();
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
            isWinnable = true;
        }
    }
    
    
    
    
    
    // simdilik T tusuna basince acılıyor
    // if player is alive and not frozen, activate the portal effect.
    public void CheckPortal()
    {
        if (!BloodController.Instance.IsAlive() && !BloodController.Instance.IsFrozen()) return;
        isWinnable = true;
        portalEffect.Play(); // Activate the portal effect.
        
    }
}
