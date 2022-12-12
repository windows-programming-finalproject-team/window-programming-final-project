using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, player;
    public new Transform camera;
    private float maxDistance = 30f;
    private SpringJoint joint;
    float minRopeScale=0.3f;
    float maxRopeScale = 0.6f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        DrawRope();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartGrapple();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            StopGrapple();
        }
    }
    //Call whenever we want to start a grapple
    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
            if (hit.transform.gameObject.layer !=6)
            {
                return;
            }
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
            //The distance grapple will try to keep from grapple point.
            joint.maxDistance = distanceFromPoint * maxRopeScale;
            joint.minDistance = distanceFromPoint * minRopeScale;
            //Change these value to fit your game.
            joint.spring = 20f;
            joint.damper = 6f;
            joint.massScale = 3f;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;//If not grappling, don't draw rope
        else
        {
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, grapplePoint);
        }
    }
    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
    public bool IsGrappling()
    {
        return joint != null;
    }
    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
