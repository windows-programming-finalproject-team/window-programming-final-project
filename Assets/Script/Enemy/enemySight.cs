using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySight : MonoBehaviour
{
    public bool playerInSight = false;
    public Vector3 playerPosition;
    float maxDistance = 10000f;// longer than the sight collider
    [SerializeField] Transform playerCam; // need this because player position is wrong

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
                playerPosition = other.transform.position;
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
