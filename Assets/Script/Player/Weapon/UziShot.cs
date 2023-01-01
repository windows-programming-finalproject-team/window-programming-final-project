using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UziShot : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    [SerializeField] GameObject Bullet;
    Rigidbody rb;    
    [SerializeField] public static int BulletNumber = 60;
    [SerializeField] ParticleSystem muzzleFlash;
    int maxBulletNumber = 60;   
    SwitchWeapon switchScript;
    [SerializeField] AudioSource shootingSound;
    [SerializeField] AudioSource reloadSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        switchScript = transform.parent.parent.parent.GetComponent<SwitchWeapon>();     
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

        if (Input.GetMouseButtonDown(0) && BulletNumber > 0)
        {
            // lmao, what is "isShotting"
            animator.SetBool("isShotting", true);
            muzzleFlash.Play();
            switchScript.isShooting = true;
            if (!shootingSound.isPlaying)
            {
                shootingSound.Play();
            }
        }
        // end shooting when you stopped/ you can't
        else if (BulletNumber <= 0 || Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShotting", false);
            muzzleFlash.Stop();
            shootingSound.Stop();

            StartCoroutine(endShooting());
        }

        // start reloading
        if (Input.GetKeyDown(KeyCode.R) || BulletNumber == 0)
        {
            if(BulletNumber < maxBulletNumber)
            {
                transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = true;
                animator.SetBool("isReloading", true);
                muzzleFlash.Stop();
                if (!reloadSound.isPlaying)
                {
                    reloadSound.Play();
                }
            }
        }
    }

    // wait for shooting animation end, then change state
    IEnumerator endShooting()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        switchScript.isShooting = false;
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
        switchScript.isReloading = false;
        reloadSound.Stop();
    }
 
}
