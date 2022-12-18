using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] Transform Sword;
    [SerializeField] Transform Uzi;
    [SerializeField] Transform ShotGun;
    [SerializeField] Transform LightGun;
    MeshRenderer SwordRender;
    MeshRenderer UziRender;
    MeshRenderer ShotGunRender;
    MeshRenderer LightGunRender;
    public bool isReloading = false;
    // Start is called before the first frame update
    void Start()
    {
        SwordRender = Sword.GetComponent<MeshRenderer>();
        UziRender = Uzi.GetComponent<MeshRenderer>();
        ShotGunRender = ShotGun.GetComponent<MeshRenderer>();
        LightGunRender = LightGun.GetComponent<MeshRenderer>();

        Uzi.gameObject.SetActive(false);
        UziRender.enabled = false;
        ShotGun.gameObject.SetActive(false);
        ShotGunRender.enabled = false;
        LightGun.gameObject.SetActive(false);
        LightGunRender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isReloading)
        {
            Sword.gameObject.SetActive(true);
            SwordRender.enabled = true;
            Uzi.gameObject.SetActive(false);
            UziRender.enabled = false;
            ShotGun.gameObject.SetActive(false);
            ShotGunRender.enabled = false;
            LightGun.gameObject.SetActive(false);
            LightGunRender.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isReloading)
        {
            Sword.gameObject.SetActive(false);
            SwordRender.enabled = false;
            Uzi.gameObject.SetActive(true);
            UziRender.enabled = true;
            ShotGun.gameObject.SetActive(false);
            ShotGunRender.enabled = false;
            LightGun.gameObject.SetActive(false);
            LightGunRender.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isReloading)
        {
            Sword.gameObject.SetActive(false);
            SwordRender.enabled = false;
            Uzi.gameObject.SetActive(false);
            UziRender.enabled = false;
            ShotGun.gameObject.SetActive(true);
            ShotGunRender.enabled = true;
            LightGun.gameObject.SetActive(false);
            LightGunRender.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !isReloading)
        {
            Sword.gameObject.SetActive(false);
            SwordRender.enabled = false;
            Uzi.gameObject.SetActive(false);
            UziRender.enabled = false;
            ShotGun.gameObject.SetActive(false);
            ShotGunRender.enabled = false;
            LightGun.gameObject.SetActive(true);
            LightGunRender.enabled = true;
        }
    }
}
