using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMenu : MonoBehaviour
{
    
    
    public void PlayPressed()
    {
        SceneManager.LoadScene("Snake");
    }
    
    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
