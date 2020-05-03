using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu Screen");      
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("Game Screen");
    }
}
