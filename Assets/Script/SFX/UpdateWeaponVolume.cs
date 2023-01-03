using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWeaponVolume : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float defaultVolume=1f;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = UpdateVolume.volume*defaultVolume;
    }
}
