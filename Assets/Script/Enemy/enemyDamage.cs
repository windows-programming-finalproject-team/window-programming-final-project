using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class enemyDamage : MonoBehaviour
{
    [SerializeField] float Life = 9;
    Animator animator;
    float destroySeconds=3f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void GetHit(float damage)
    {
        Life -= damage;
        if(Life <= 0)
        {
            animator.SetBool("dead", true);
            // maybe explosion and sfx
            StartCoroutine(waitForDestroy());
        }
    }

    IEnumerator waitForDestroy()
    {
        yield return new WaitForSeconds(destroySeconds);
        Destroy(transform.gameObject);
    }
}
