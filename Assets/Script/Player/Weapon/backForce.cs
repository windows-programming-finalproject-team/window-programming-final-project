using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class backForce : MonoBehaviour
{
    [SerializeField] new Transform camera;
    [SerializeField] float power;
    [SerializeField] GameObject shotgun;
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
        // not holding shotgun
        if (!shotgun.activeSelf)
            return;

        // holding shotgun, but shotgun is still cooling
        if (shotgun.GetComponent<ShotGunShot>().cooling||PauseController.isPausing||DeathController.isDeath)
        {
            return;
        }

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
