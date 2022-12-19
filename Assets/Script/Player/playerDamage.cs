using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    [SerializeField] float Life = 10;
    public void GetHit(float damage)
    {
        Life -= damage;
        if(Life <= 0)
        {
            //todo
        }
    }
}
