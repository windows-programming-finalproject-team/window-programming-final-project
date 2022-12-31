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
            switchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isReloading)
        {
            switchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isReloading)
        {
            switchWeapon(2);
        }
        // NOTE there's no laser gun
        if (Input.GetKeyDown(KeyCode.Alpha4) && !isReloading)
        {
            switchWeapon(3);
        }
    }

    public void switchWeapon(int index)
    {
        if (index < 0 || index >= 3)
        {
            Debug.Log("weapon index doesn't exist");
            return;
        }

        // disable every weapon
        Sword.gameObject.SetActive(false);
        SwordRender.enabled = false;
        Uzi.gameObject.SetActive(false);
        UziRender.enabled = false;
        ShotGun.gameObject.SetActive(false);
        ShotGunRender.enabled = false;
        LightGun.gameObject.SetActive(false);
        LightGunRender.enabled = false;

        if (index == 0)
        {
            Sword.gameObject.SetActive(true);
            SwordRender.enabled = true;
        }
        else if (index == 1)
        {
            Uzi.gameObject.SetActive(true);
            UziRender.enabled = true;
        }
        else if (index == 2)
        {
            ShotGun.gameObject.SetActive(true);
            ShotGunRender.enabled = true;
        }
    }
}
