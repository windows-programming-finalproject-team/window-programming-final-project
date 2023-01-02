using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwake : MonoBehaviour
{
    // checking play on awake in audio source setting seem to have a problem, so I wrote this
    private void Awake()
    {
        GetComponent<AudioSource>().Play();
    }
}
