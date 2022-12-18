using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            //todo
            Destroy(transform.parent.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            //todo
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //todo
            Destroy(transform.parent.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            //todo
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //todo
            Destroy(transform.parent.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            //todo
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
