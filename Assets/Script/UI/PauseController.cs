using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject targetDeath;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && DeathController.isDeath==false)
        {
            PauseGame();
        }
    }
    void PauseGame()
    {
        target.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioListener.pause=true;// mute player
    }
}
