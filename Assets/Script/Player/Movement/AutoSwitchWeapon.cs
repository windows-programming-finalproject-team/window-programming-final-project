using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwitchWeapon))]
// Auto switch to katana when player tries to swing
public class AutoSwitchWeapon : MonoBehaviour
{
    [SerializeField] Transform katana;
    SwitchWeapon switchScript;

    // Start is called before the first frame update
    void Start()
    {
        switchScript=GetComponent<SwitchWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        // is already holding katana
        if (switchScript.enablingKatana)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // switch to katana
            switchScript.switchWeapon(0);
        }
    }
}
