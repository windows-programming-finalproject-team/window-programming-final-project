using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revive : MonoBehaviour
{
    public void revive()
    {
        PauseController.isPausing = false;
        DeathController.isDeath = false;
        // reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     
    }
}
