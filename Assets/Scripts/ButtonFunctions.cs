using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update

    
    //load up a scene
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    //quit button
    public void QuitGame()
    {
        Application.Quit();
    }

}
