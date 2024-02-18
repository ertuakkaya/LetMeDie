using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void RestartBotton()
    {
        SceneManager.LoadScene("Level");
    }

   public void MainMenuButton()
    {
        SceneManager.LoadScene("Dilara");


    } 
   
}
