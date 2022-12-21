using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class backForce : MonoBehaviour
{
    // TODO check if it's shotgun 
    [SerializeField] new Transform camera;
    [SerializeField] float power;
    private float maxDistance = 200f;
    Rigidbody rb;
    public static bool isUsingBackForce = false;
    float thresholdSpeed = 20;// when can user control player again

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
            {
                if (hit.transform.gameObject.layer != 7)
                {
                    return;
                }

                rb.velocity += (camera.transform.forward)* -1 * power;
                isUsingBackForce = true;
            }
        }
        else if (rb.velocity.magnitude < thresholdSpeed)
        {
            isUsingBackForce = false;
        }
    }
}
