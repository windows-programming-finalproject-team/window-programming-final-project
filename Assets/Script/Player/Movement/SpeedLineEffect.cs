using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLineEffect : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]ParticleSystem speedEffect;
    float thresholdVelocity = 10f;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        StartCoroutine(pastOneSecond());
    }

    // player has past threshold velocity for one second
    IEnumerator pastOneSecond()
    {
        while (true)
        {
            if (rb.velocity.magnitude < thresholdVelocity)
            {
                speedEffect.enableEmission = false;
                yield return new WaitForSecondsRealtime(1);
            }
            else
            {
                speedEffect.enableEmission = true;
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
    }
}
