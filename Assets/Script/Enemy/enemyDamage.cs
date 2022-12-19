using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    [SerializeField] float Life = 9;
    public void GetHit(float damage)
    {
        Life -= damage;
        if(Life <= 0)
        {
            //todo
        }
    }
}
