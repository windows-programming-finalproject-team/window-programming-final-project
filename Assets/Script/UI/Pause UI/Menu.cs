using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
