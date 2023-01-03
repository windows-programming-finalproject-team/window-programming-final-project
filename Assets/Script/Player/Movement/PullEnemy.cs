using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KatanaAttack))]

public class PullEnemy : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, player;
    [SerializeField] Rigidbody playerRb;
    public new Transform camera;
    private float maxDistance = 100f;
    [SerializeField] float pullForce = 20f;
    float minDistance = 2f;
    public static bool grappling = false;
    Animator animator;
    [SerializeField] AudioSource ropeSound;
    [SerializeField] AudioSource attackSound;
    SwitchWeapon switchScript;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        // make lr invisible
        lr.enabled = false;
        switchScript = transform.parent.parent.parent.GetComponent<SwitchWeapon>();
    }

    private void Update()
    {
        if (!switchScript.enablingKatana)
        {
            return;
        }

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

            ropeSound.Play();

            while (Input.GetKey(KeyCode.Q) && Vector3.Distance(player.position, grapplePoint) > minDistance)
            {
                grapplePoint = hit.point;
                grappling = true;

                playerRb.velocity = (grapplePoint - player.transform.position).normalized * pullForce;

                lr.positionCount = 2;
                yield return new WaitForSecondsRealtime(0.1f);
            }

            // too close with enemy, will stop pulling
            grappling = false;
            playerRb.velocity = Vector3.zero;
            lr.enabled = false;

            //auto attack
            animator.SetBool("isAttack", true);
            attackSound.Play();
            GetComponent<KatanaAttack>().Attack();
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
        ropeSound.Stop();
    }
}
