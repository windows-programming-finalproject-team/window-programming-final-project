using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class enemyDamage : MonoBehaviour
{
    [SerializeField] float Life = 9;
    Animator animator;
    float destroySeconds = 2f;
    float explosionTime = 1.8f;
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] AudioSource explosionSound;
    bool hasExploded = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        deathExplosion.Stop();
    }
    public void GetHit(float damage)
    {
        Life -= damage;
        if (Life <= 0)
        {
            animator.SetBool("dead", true);
            if (!hasExploded)
            {
                deathExplosion.Play();
                explosionSound.Play();
                hasExploded = true;
                StartCoroutine(waitForDestroy());
            }

        }
    }

    IEnumerator waitForDestroy()
    {
        yield return new WaitForSeconds(explosionTime);
        deathExplosion.Stop();
        explosionSound.Stop();

        yield return new WaitForSeconds(destroySeconds - explosionTime);
        Destroy(transform.gameObject);
    }
}
