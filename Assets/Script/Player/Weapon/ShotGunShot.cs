using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShot : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    [SerializeField] GameObject Bullet;
    Rigidbody rb;
    [SerializeField] int MaxBulletNumber = 3;
    int CurrentBulletNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CurrentBulletNumber = MaxBulletNumber;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Shotgun ammo:{CurrentBulletNumber}");

        info = animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetMouseButtonDown(0) && CurrentBulletNumber > 0)
        {
            animator.SetBool("isShotting", true);
            Shot();
        }
        if (CurrentBulletNumber <= 0 || Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShotting", false);
        }
        if (Input.GetKeyDown(KeyCode.R) || CurrentBulletNumber == 0)
        {
            if (CurrentBulletNumber < MaxBulletNumber)
            {
                transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = true;
                animator.SetBool("isReloading", true);
            }
        }
    }
    // called in animation event
    void Shot()
    {
        if (CurrentBulletNumber > 0)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector3 position = new Vector3(transform.GetChild(13).transform.position.x + Random.Range(-1.0f, 1.0f), transform.GetChild(13).transform.position.y + Random.Range(-1.0f, 1.0f), transform.GetChild(13).transform.position.z);
                GameObject ShotGunBullet = Instantiate(Bullet, position, transform.GetChild(13).transform.rotation);
                rb = ShotGunBullet.GetComponent<Rigidbody>();
                rb.velocity = 40 * ShotGunBullet.transform.forward;
            }
            CurrentBulletNumber--;
        }
    }

    // called in animation event
    void Reload()
    {
        CurrentBulletNumber = MaxBulletNumber;
        animator.SetBool("isReloading", false);
        transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = false;
    }
}
