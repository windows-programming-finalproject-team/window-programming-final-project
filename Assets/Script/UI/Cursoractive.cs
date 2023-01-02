using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursoractive : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
