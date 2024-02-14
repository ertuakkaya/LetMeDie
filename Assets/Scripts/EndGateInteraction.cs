using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGateInteraction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Game Manager'dan EndTheLevel()'� �a��r�yor.
            var gm = FindObjectOfType<GameManager>();
            gm.EndTheLevel();
        }
    }


}
