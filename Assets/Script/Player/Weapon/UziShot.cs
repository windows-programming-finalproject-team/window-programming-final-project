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
    float reloadTime = 0.9f;
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
        Debug.Log($"UZI ammo:{BulletNumber}");
        // NOTE add else to prevent reloading while shooting

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
                
                // force player to wait certain time so I don't need to detect animation
                StartCoroutine(waitForReload());
            }
        }
    }

    IEnumerator waitForReload()
    {
        yield return new WaitForSecondsRealtime(reloadTime);
        DoneReloading();
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
    void DoneReloading()
    {
        BulletNumber = maxBulletNumber;
        animator.SetBool("isReloading", false);
        transform.parent.parent.parent.GetComponent<SwitchWeapon>().isReloading = false;
    }
}
