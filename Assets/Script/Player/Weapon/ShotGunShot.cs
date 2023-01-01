using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShot : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    [SerializeField] GameObject Bullet;
    Rigidbody rb;
    [SerializeField] public static int MaxBulletNumber = 3;
    public static int CurrentBulletNumber = 0;
    [SerializeField] ParticleSystem muzzleFlash;
    bool cooling = false;
    float coolingTime = 0.8f;
    SwitchWeapon switchScript;
    [SerializeField] AudioSource reloadSound;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        switchScript = transform.parent.parent.parent.GetComponent<SwitchWeapon>();

        CurrentBulletNumber = MaxBulletNumber;
        muzzleFlash.Stop();
    }

    // need to use this function for switching weapon
    private void OnEnable()
    {
        muzzleFlash.Stop();
        cooling = false;
    }

    // Update is called once per frame
    void Update()
    {
        // for debug
        Debug.Log($"Shotgun ammo:{CurrentBulletNumber}");

        info = animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetMouseButtonDown(0) && CurrentBulletNumber > 0&& ! cooling)
        {
            animator.SetBool("isShotting", true);
            Shot();
            muzzleFlash.Play();
            switchScript.isShooting = true;

            // prevent continuous shooting like UZI
            cooling = true;
            StartCoroutine(ResetCooling());
        }
        else if (CurrentBulletNumber <= 0 || Input.GetMouseButtonUp(0)||cooling)
        {
            animator.SetBool("isShotting", false);
            muzzleFlash.Stop();
            StartCoroutine(endShooting());

        }

        if (Input.GetKeyDown(KeyCode.R) || CurrentBulletNumber == 0)
        {
            if (CurrentBulletNumber < MaxBulletNumber)
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

    IEnumerator ResetCooling()
    {
        yield return new WaitForSecondsRealtime(coolingTime);
        cooling = false;
    }

    // wait for shooting animation end, then change state
    IEnumerator endShooting()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        switchScript.isShooting = false;
    }

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
        switchScript.isReloading = false;
        reloadSound.Stop();
    }
}
