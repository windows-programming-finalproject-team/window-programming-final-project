using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziBullet : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] ParticleSystem hitSpark;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] Rigidbody rb;
    
    private void Start()
    {
        hitSpark.Stop();
        explosion.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.GetComponent<enemyDamage>().GetHit(damage);
            // make spark stay
            rb.velocity = Vector3.zero;
            explosion.Play();
            StartCoroutine(destroyBullet());
        }
        else
        {
            rb.velocity = Vector3.zero;
            hitSpark.Play();
            StartCoroutine(destroyBullet());

        }
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        explosion.Stop();
        hitSpark.Stop();
        Destroy(transform.parent.gameObject);
    }
}
