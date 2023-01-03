using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWeaponVolume : MonoBehaviour
{
    AudioSource audiosoure;
    // Start is called before the first frame update
    private void Awake()
    {
        audiosoure = GetComponent<AudioSource>();
        audiosoure.volume = UpdateVolume.volume;
    }
}
