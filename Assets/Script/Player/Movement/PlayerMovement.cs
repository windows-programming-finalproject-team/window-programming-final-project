using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movingSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] new Camera camera;
    bool isGround, isSliding, onWall;
    Rigidbody rb;
    MeshRenderer render;
    CapsuleCollider capsuleCollider;
    float originalColliderHeight;
    float slidingColliderHeight = 1;
    float slidingCameraTransform = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = true;
        isSliding = false;
        onWall = false;
        Cursor.lockState = CursorLockMode.Locked;//Lock cursor to the center of the game window but invisible
        render = GetComponent<MeshRenderer>();
        render.enabled = false;//Make player invisible
        capsuleCollider = GetComponent<CapsuleCollider>();
        originalColliderHeight = capsuleCollider.height;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 newHorizontalSpeed = horizontalInput * movingSpeed * transform.right;
        Vector3 newVerticalSpeed = verticalInput * movingSpeed * transform.forward;

        if (!onWall)
        {
            if (!isSliding)
            {
                rb.velocity = newHorizontalSpeed + newVerticalSpeed + new Vector3(0,rb.velocity.y,0);

                if (isGround && Input.GetKey(KeyCode.Space))
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
                }
                if (isGround && Input.GetKey(KeyCode.LeftShift))
                {
                    camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - slidingCameraTransform, camera.transform.position.z);
                    rb.velocity = transform.forward * slideSpeed;
                    isSliding = true;
                    capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y - (originalColliderHeight-slidingColliderHeight)/2, capsuleCollider.center.z);
                    capsuleCollider.height = slidingColliderHeight;
                }
            }
            else
            {
                if (rb.velocity == new Vector3(0, 0, 0))
                {
                    camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + slidingCameraTransform, camera.transform.position.z);
                    isSliding = false;
                    capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y + (originalColliderHeight-slidingColliderHeight)/2, capsuleCollider.center.z);
                    capsuleCollider.height = originalColliderHeight;
                }
            }
        }
        else
        {
            rb.velocity = 2*movingSpeed*transform.forward;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground") isGround = true;
        else if (collision.gameObject.tag == "wallrunTile")
        {
            onWall = true;
            rb.velocity = new Vector3(0, 0, 0);
            rb.useGravity = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        onWall = false;
        if (collision.gameObject.tag == "ground") isGround = false;
        else if (collision.gameObject.tag == "wallrunTile")
        {
            rb.velocity = new Vector3(0, jumpSpeed, 0);
            rb.AddForce(transform.forward * 30);
            rb.useGravity = true;
        }
    }
}
