using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{ 
    [SerializeField] protected int blood = 100;
    [SerializeField] protected bool isAlive = true;
    [SerializeField] protected bool isFrozen = false; 

    public Slider slider;
    public static BloodController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public int GetBlood()
    {
        return blood;
    }

    public void ChangeBlood(int amount)
    {
        blood += amount;

        // 0 < health <= 100

        if (blood > 100)
        {
            blood = 100;
        }
        else if (blood <= 0)
        {
            blood = 0;
            isFrozen = true;
        }

        slider.value = blood;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public bool IsFrozen()
    {
        return isFrozen;
    }

    public void KillCharacter()
    { 
        isAlive = false;
    } 
}
