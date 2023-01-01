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
    [SerializeField] ParticleSystem muzzleFlash;
    int maxBulletNumber = 60;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        muzzleFlash.Stop();
    }

    // need to use this function for switching weapon
    private void OnEnable()
    {
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // NOTE add else to prevent reloading while shooting

        // Debug ammo count
        Debug.Log($"Uzi ammo: {BulletNumber}");
        // start shooting
        if (Input.GetMouseButtonDown(0) && BulletNumber > 0)
        {
            // lmao, what is "isShotting"
            animator.SetBool("isShotting", true);
            muzzleFlash.Play();
        }
        // end shooting when you stopped/ you can't
        else if (BulletNumber <= 0 || Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShotting", false);
            muzzleFlash.Stop();
        }

        // start reloading
        if (Input.GetKeyDown(KeyCode.R) || BulletNumber == 0)
        {
            if(BulletNumber < maxBulletNumber)
            {
                transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = true;
                animator.SetBool("isReloading", true);
                muzzleFlash.Stop();
            }
        }
    }

    // called in animation event
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

    // called in animation event
    void Reload()
    {
        BulletNumber = maxBulletNumber;
        animator.SetBool("isReloading", false);
        transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = false;
    }
}
