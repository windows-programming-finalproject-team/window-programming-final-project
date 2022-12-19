using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziShot : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    [SerializeField] GameObject Bullet;
    Rigidbody rb;
    [SerializeField] int BulletNumber = 60;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && BulletNumber > 0)
        {
            animator.SetBool("isShotting", true);
        }
        if (BulletNumber <= 0 || Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShotting", false);
        }
        if (Input.GetKeyDown(KeyCode.R) || BulletNumber == 0)
        {
            if(BulletNumber < 60)
            {
                transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = true;
                animator.SetBool("isReloading", true);
            }
        }
    }
    void Shot()
    {
        if (BulletNumber > 0)
        {
            GameObject UziBullet = Instantiate(Bullet, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
            BulletNumber--;
            rb = UziBullet.GetComponent<Rigidbody>();
            rb.velocity = 50 * UziBullet.transform.forward;
        }
    }
    void Reload()
    {
        BulletNumber = 60;
        animator.SetBool("isReloading", false);
        transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = false;
    }
}
