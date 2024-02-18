using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGateInteraction : MonoBehaviour
{   
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Game Manager'dan EndTheLevel()'ý çaðýrýyor.
            var gm = FindObjectOfType<GameManager>();
            gm.EndTheLevel();
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Game Manager'dan EndTheLevel()'ý çaðýrýyor.
            var gm = FindObjectOfType<GameManager>();
            gm.EndTheLevel();
        }
    }
}
