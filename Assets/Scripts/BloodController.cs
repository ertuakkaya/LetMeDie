using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{ 
    [SerializeField] protected int blood = 100;
    [SerializeField] protected bool isAlive = true;
    [SerializeField] protected bool isFrozen = false;

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
