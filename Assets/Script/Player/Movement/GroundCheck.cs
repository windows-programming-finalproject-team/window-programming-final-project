using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask shotgunTile;
    public bool isOnGround = true;

    private void Update()
    {
        isOnGround = Physics.CheckSphere(transform.position, .2f, ground)
            || Physics.CheckSphere(transform.position, .2f, shotgunTile);
    }
}
