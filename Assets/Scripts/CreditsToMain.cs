using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainMenu());
    }
    
    
    IEnumerator LoadMainMenu()
    {
        //wait for 5 seconds then load main menu
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main Menu");
    }
}
