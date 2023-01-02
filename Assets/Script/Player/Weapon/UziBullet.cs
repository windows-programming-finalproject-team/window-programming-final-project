using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziBullet : MonoBehaviour
{
    [SerializeField] float damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyDamage>().GetHit(damage);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyDamage>().GetHit(damage);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyDamage>().GetHit(damage);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
