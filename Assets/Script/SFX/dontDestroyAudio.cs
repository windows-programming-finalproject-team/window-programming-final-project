using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour
{
    public static dontDestroyAudio instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            // prevent audio overlapping
            Destroy(gameObject);
        }
       
    }

    private void Update()
    {
        if (Menu.ismenu == true)
        {
            Destroy(gameObject);
            Menu.ismenu = false;
        }
    }
}
