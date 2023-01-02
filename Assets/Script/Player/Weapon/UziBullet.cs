using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziBullet : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] ParticleSystem hitSpark;
    [SerializeField] Rigidbody rb;
    private void Start()
    {
        hitSpark.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyDamage>().GetHit(damage);
            // make spark stay
            rb.velocity = Vector3.zero;
            StartCoroutine(destroyBullet());
        }
        else
        {
            rb.velocity = Vector3.zero;
            StartCoroutine(destroyBullet());

        }
    }

    IEnumerator destroyBullet()
    {
        hitSpark.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        hitSpark.Stop();
        Destroy(transform.parent.gameObject);
    }
}
