using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySight : MonoBehaviour
{
    public bool playerInSight = false;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object is within the cone collider
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("in sight");
            playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("out of sight");
            playerInSight = false;
        }
    }
}
