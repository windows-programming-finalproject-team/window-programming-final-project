using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAirwall : MonoBehaviour
{
    [SerializeField] GameObject remindCanvas;
    void Start()
    {
        remindCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            remindCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            remindCanvas.SetActive(false);
        }
    }
}
