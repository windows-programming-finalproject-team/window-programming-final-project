using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] Transform SwordPosition;
    [SerializeField] Transform Uzi;
    [SerializeField] Transform ShotGun;
    MeshRenderer UziRender;
    MeshRenderer ShotGunRender;
    public bool isReloading = false;
    public bool enablingKatana = true;

    // how long does katana move on x axis when disabled
    float katanaMoveDistance = 10000;

    void Start()
    {
        UziRender = Uzi.GetComponent<MeshRenderer>();
        ShotGunRender = ShotGun.GetComponent<MeshRenderer>();

        switchWeapon(0);
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
    }

    public void switchWeapon(int index)
    {
        if (index < 0 || index >= 3)
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
                SwordPosition.localPosition -= new Vector3(katanaMoveDistance, 0, 0);
                enablingKatana = true;
            }
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
