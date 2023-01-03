using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSensitivity : MonoBehaviour
{
    public static float sensitivity=100f;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void updateSensitivity()
    {
        sensitivity = slider.value;
    }
}
