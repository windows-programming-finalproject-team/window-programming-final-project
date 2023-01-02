using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    [SerializeField] float damage = 3;
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
        else if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerDamage>().GetHit(damage);
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
        else if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerDamage>().GetHit(damage);
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
        else if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerDamage>().GetHit(damage);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
