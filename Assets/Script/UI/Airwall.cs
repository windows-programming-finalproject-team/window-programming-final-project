using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airwall : MonoBehaviour
{
    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;
    [SerializeField] GameObject target3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("airwalljump"))
        {
            target1.SetActive(true);
        }
        if (other.CompareTag("airwallslide"))
        {
            target2.SetActive(true);
        }
        if (other.CompareTag("airwallaccelerate"))
        {
            target3.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("airwalljump"))
        {
            target1.SetActive(false);
        }
        if (other.CompareTag("airwallslide"))
        {
            target2.SetActive(false);
        }
        if (other.CompareTag("airwallaccelerate"))
        {
            target3.SetActive(false);
        }
    }
}
