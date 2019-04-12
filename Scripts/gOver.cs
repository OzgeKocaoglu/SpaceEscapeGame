using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gOver : MonoBehaviour
{

    
   
    
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        ScoreTextScript.coinAmount = 0;
        GameMaster.currentHeath = 3;

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    



}
