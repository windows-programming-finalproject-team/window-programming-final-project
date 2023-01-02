using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool ismenu=false;
    public void GoMenu()
    {
        ismenu = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);       
        AudioListener.pause = false;   
        PauseController.isPausing = false;
    }
}
