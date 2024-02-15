using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void RestartBotton()
    {
        SceneManager.LoadScene(4);
    }

   public void MainMenuButton()
    {
        SceneManager.LoadScene("Dilara");


    } 
   
}
