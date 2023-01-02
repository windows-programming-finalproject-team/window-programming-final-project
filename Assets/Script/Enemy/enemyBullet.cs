using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] float damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy")||other.isTrigger)
        {
            return;
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
