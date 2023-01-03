using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDamage : MonoBehaviour
{
    [SerializeField] float Life = 10;
    TextMeshProUGUI hp;
    private void Start()
    {
        hp = GetComponent<SwitchWeaponCanvas>().HP;

        // has a lot of life in easy mode
        if (ChooseDifficulty.isEasyMode)
        {
            Life = 99999;
            hp.text = "HP : Infinite";
        }

    }
    public void GetHit(float damage)
    {
        // can't take damage in easy mode
        if (ChooseDifficulty.isEasyMode)
        {
            return;
        }

        Life -= damage;
        hp.text = "HP : " + Life;
        if(Life <= 0)
        {
            GetComponent<DeathController>().DeathEvent();
        }
    }
}
