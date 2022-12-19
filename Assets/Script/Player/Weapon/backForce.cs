using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backForce : MonoBehaviour
{
    // TODO check if it's shotgun 
    [SerializeField] new Transform camera;
    [SerializeField] float power;
    private float maxDistance = 200f;
    Rigidbody rb;

    private void Start()
    {
        rb = transform.parent.parent.parent.GetComponent<Rigidbody>();
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

                rb.velocity =rb.velocity+ camera.transform.forward * -1 * power;
            }

        }
    }
}
