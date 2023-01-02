using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    // need to use a script to follow camera else BGM will be destroyed on load
    void Update()
    {
        transform.position = Camera.main.transform.position;
    }
}
