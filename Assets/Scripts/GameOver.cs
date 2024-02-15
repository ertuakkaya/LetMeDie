using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   public void RestartBotton()
    {
        Main_menu.Instance.PlayButton();
    }

   public void MainMenuButton()
    {
        Main_menu.Instance.BackButton();

    } 
   public void StopMusic()
    {
        Main_menu.Instance.StopMusic();
    }

    public void StartMusic()
    {
        Main_menu.Instance.StartMusic();
    }
}
