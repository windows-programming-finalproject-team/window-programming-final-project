using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    [SerializeField] GameObject target;
    public void ContinueGame()
    {    
        Time.timeScale = 2;
        target.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        AudioListener.pause = false;
        PauseController.isPausing = false;
    }
}
