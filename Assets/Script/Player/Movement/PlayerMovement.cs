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
    }

    // Update is called once per frame
    void Update()
    {
        if (!onWall)
        {
            if (!isSliding)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += movingSpeed * Time.deltaTime * transform.forward;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= movingSpeed * Time.deltaTime * transform.forward;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= movingSpeed * Time.deltaTime * transform.right;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += movingSpeed * Time.deltaTime * transform.right;
                }
                if (isGround && Input.GetKey(KeyCode.Space))
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
                }
                if (isGround && Input.GetKey(KeyCode.LeftShift))
                {
                    camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - (float)0.2, camera.transform.position.z);
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.velocity = transform.forward * slideSpeed;
                    isSliding = true;
                    capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y - (float)0.5, capsuleCollider.center.z);
                    capsuleCollider.height = 1;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= movingSpeed * Time.deltaTime * transform.right;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += movingSpeed * Time.deltaTime * transform.right;
                }
                if (rb.velocity == new Vector3(0, 0, 0))
                {
                    camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (float)0.2, camera.transform.position.z);
                    isSliding = false;
                    capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y + (float)0.5, capsuleCollider.center.z);
                    capsuleCollider.height = 2;
                }
            }
        }
        else
        {
            transform.position += 2 * movingSpeed * Time.deltaTime * transform.forward;//If the player in wall then move forward automatically
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground") isGround = true;
        else if (collision.gameObject.tag == "wall")
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
        else if (collision.gameObject.tag == "wall")
        {
            rb.velocity = new Vector3(0, jumpSpeed, 0);
            rb.AddForce(transform.forward * 30);
            rb.useGravity = true;
        }
    }
}
