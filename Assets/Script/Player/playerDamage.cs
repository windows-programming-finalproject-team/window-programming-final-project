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
    }
    public void GetHit(float damage)
    {
        Life -= damage;
        hp.text = "HP : " + Life;
        if(Life <= 0)
        {
            GetComponent<DeathController>().DeathEvent();
        }
    }
}
