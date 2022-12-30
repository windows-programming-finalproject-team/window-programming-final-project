using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    Canvas canvas;

    /*private void Start()
    {
        canvas = GetComponent<Canvas>();
    }*/
    public void PauseGame()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }
}
