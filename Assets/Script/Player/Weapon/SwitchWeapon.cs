using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] Transform SwordPosition;
    [SerializeField] Transform Uzi;
    [SerializeField] Transform ShotGun;
    [SerializeField] Sprite uzi;
    [SerializeField] Sprite shotgun;
    [SerializeField] Sprite katana;
    MeshRenderer UziRender;
    MeshRenderer ShotGunRender;
    TextMeshProUGUI bulletNum_ref;
    Image im;
    public bool isReloading = false;
    public bool enablingKatana = true;
    public bool isShooting = false;
    int option;

    // how long does katana move on x axis when disabled
    float katanaMoveDistance = 10000;

    void Start()
    {
        UziRender = Uzi.GetComponent<MeshRenderer>();
        ShotGunRender = ShotGun.GetComponent<MeshRenderer>();
        bulletNum_ref = GetComponent<SwitchWeaponCanvas>().bulletNum;
        im = GetComponent<SwitchWeaponCanvas>().image;        
        switchWeapon(0);
        option = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isReloading && !isShooting)
        {
            switchWeapon(0);
            im.sprite = katana;
            option = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isReloading && !isShooting)
        {
            switchWeapon(1);
            im.sprite = uzi;
            option = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isReloading && !isShooting)
        {
            switchWeapon(2);
            im.sprite = shotgun;
            option = 2;
        }

        if (option == 0)
        {
            bulletNum_ref.text = "Infinity";
        }
        else if (option == 1)
        {
            bulletNum_ref.text = UziShot.BulletNumber + "/60";
        }
        else if (option == 2)
        {
            bulletNum_ref.text = ShotGunShot.CurrentBulletNumber + "/3";
        }
    }

    public void switchWeapon(int index)
    {
        if (index < 0 || index >= 3||isReloading||isShooting)
        {
            return;
        }

        if (enablingKatana)
        {       
            SwordPosition.localPosition += new Vector3(katanaMoveDistance, 0, 0);
            enablingKatana = false;
        }
        Uzi.gameObject.SetActive(false);
        UziRender.enabled = false;
        ShotGun.gameObject.SetActive(false);
        ShotGunRender.enabled = false;

        if (index == 0)
        {
            if (!enablingKatana)
            {
                bulletNum_ref.text = "Infinity";
                SwordPosition.localPosition -= new Vector3(katanaMoveDistance, 0, 0);
                enablingKatana = true;
            }
        }
        else if (index == 1)
        {
           bulletNum_ref.text= UziShot.BulletNumber+"/60";
            Uzi.gameObject.SetActive(true);
            UziRender.enabled = true;
        }
        else if (index == 2)
        {
            bulletNum_ref.text= ShotGunShot.CurrentBulletNumber + "/3";
            ShotGun.gameObject.SetActive(true);
            ShotGunRender.enabled = true;
        }
    }
}
