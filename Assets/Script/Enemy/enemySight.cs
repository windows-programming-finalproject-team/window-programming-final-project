using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySight : MonoBehaviour
{
    public bool playerInSight = false;
    float maxDistance = 10000f;// longer than the sight collider
    private void OnTriggerStay(Collider other)
    {
        // Check if the other object is within the cone collider
        if (other.gameObject.CompareTag("Player"))
        {
            RaycastHit hit;
            Vector3 differnce = other.transform.position - transform.position; // vector from enemy to player
            if (Physics.Raycast(transform.position, differnce, out hit, maxDistance))
            {
                if (hit.transform.gameObject.layer != 12)// player layer
                {
                    playerInSight = false;
                    return;
                }

                // not blocked by wall/ other stuff

                playerInSight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}
