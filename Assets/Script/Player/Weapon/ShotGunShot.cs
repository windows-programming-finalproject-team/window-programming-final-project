using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShot : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    [SerializeField] GameObject Bullet;
    Rigidbody rb;
    [SerializeField] int BulletNumber = 3;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
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
            if (BulletNumber < 60)
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
            for (int i = 0; i < 8; i++)
            {
                Vector3 position = new Vector3(transform.GetChild(13).transform.position.x + Random.Range(-1.0f, 1.0f), transform.GetChild(13).transform.position.y + Random.Range(-1.0f, 1.0f), transform.GetChild(13).transform.position.z);
                GameObject ShotGunBullet = Instantiate(Bullet, position, transform.GetChild(13).transform.rotation);
                rb = ShotGunBullet.GetComponent<Rigidbody>();
                rb.velocity = 40 * ShotGunBullet.transform.forward;
            }
            BulletNumber--;
        }
    }
    void Reload()
    {
        BulletNumber = 3;
        animator.SetBool("isReloading", false);
        transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = false;
    }
}
