using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullEnemy : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, player;
    [SerializeField] Rigidbody playerRb;
    public new Transform camera;
    private float maxDistance = 60f;
    [SerializeField] float pullForce = 20f;
    float minDistance = 5f;
    public static bool grappling = false;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        // make lr invisible
        lr.enabled = false;
    }

    private void Update()
    {
        DrawRope();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(StartGrapple());
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            StopGrapple();
        }
    }

    //Call whenever we want to start a grapple
    IEnumerator StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
            if (hit.transform.gameObject.layer != 11)
            {
                yield break;
            }


            while (Input.GetKey(KeyCode.Q) && Vector3.Distance(player.position, grapplePoint) > minDistance)
            {
                grapplePoint = hit.point;
                grappling = true;

                playerRb.velocity = (grapplePoint - player.transform.position).normalized * pullForce;

                lr.positionCount = 2;
                yield return new WaitForSecondsRealtime(0.1f);
            }

            grappling = false;
            playerRb.velocity = Vector3.zero;
            lr.enabled = false;
        }
    }

    void DrawRope()
    {
        if (!grappling) return;//If not grappling, don't draw rope
        else
        {
            lr.enabled = true;
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, grapplePoint);
        }
    }
    private void StopGrapple()
    {
        lr.enabled = false;
        lr.positionCount = 0;
        grappling = false;
    }
}
