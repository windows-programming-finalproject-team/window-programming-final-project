using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class enemyAI : MonoBehaviour
{
    enemySight sightScript;
    Animator animator;

    private void Start()
    {
        sightScript = transform.GetComponentInChildren<enemySight>();
        animator=GetComponent<Animator>();
    }

    private void Update()
    {
        if (sightScript.playerInSight)
        {
            animator.SetBool("playerInSight", true);
            
            Vector3 playerPosition = sightScript.player.position;
            // only rotate along y axis
            Vector3 lookPoint = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.LookAt(lookPoint);
        }
        else if(!sightScript.playerInSight)
        {
            animator.SetBool("playerInSight", false);
        }
    }
}
