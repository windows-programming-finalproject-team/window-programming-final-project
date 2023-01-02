using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class enemyAI : MonoBehaviour
{
    enemySight sightScript;
    Animator animator;
    [SerializeField] GameObject enemyBullet;
    [SerializeField]Transform gunTip;
    float coolingTime = 1;
    bool aimingAtPlayer=false;

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
            
            Vector3 playerPosition = sightScript.playerPosition;
            // only rotate along y axis
            Vector3 lookPoint = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.LookAt(lookPoint);

            if (!aimingAtPlayer)
            {
                aimingAtPlayer = true;
                StartCoroutine(shootWithCooling());
            }
        }
        else if(!sightScript.playerInSight)
        {
            // pause shooting when paused
            animator.SetBool("playerInSight", false);
            aimingAtPlayer = false;
        }
    }

    IEnumerator shootWithCooling()
    {
        while (aimingAtPlayer)
        {
            yield return new WaitForSecondsRealtime(coolingTime);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject UziBullet = Instantiate(enemyBullet, transform.GetChild(3).transform.position, transform.GetChild(3).transform.rotation);
        Rigidbody rb = UziBullet.GetComponent<Rigidbody>();

        Vector3 shootDirection=(sightScript.playerPosition-gunTip.position).normalized;
        
        rb.velocity = 10 * shootDirection;
    }
}
