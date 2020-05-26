using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadMenuScreen()
    {
        SceneManager.LoadScene("Menu Screen");      
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("Game Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits Screen");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial Screen");
    }
}
