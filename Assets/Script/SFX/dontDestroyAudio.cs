using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour
{
    public static dontDestroyAudio instance;
    AudioSource audioSource;
    [SerializeField] float defaultVolume;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = UpdateVolume.volume*defaultVolume;
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
