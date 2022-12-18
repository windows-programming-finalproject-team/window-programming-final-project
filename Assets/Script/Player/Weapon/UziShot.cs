using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziShot : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    int BulletNumber = 60;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetMouseButtonDown(0))
        {
            
            animator.SetBool("isShotting", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShotting", false);
        }
    }
    void Shot()
    {

    }
}
