using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaAttack : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;
    bool isGrappling;
    [SerializeField] float damage = 10;
    [SerializeField] float AttackRange = 0.025f;
    [SerializeField] Transform AttackPoint;
    [SerializeField] LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        isGrappling = transform.GetComponent<GrapplingGun>().IsGrappling();
        if(info.normalizedTime >= 0.99f)
        {
            animator.SetBool("isAttack", false);
        }
        if (!isGrappling && Input.GetMouseButtonDown(0))
        {

            animator.SetBool("isAttack", true);
        }
    }
    public void Attack()
    {
        Collider[] hit = Physics.OverlapSphere(AttackPoint.position, AttackRange, enemyLayer);
        foreach (Collider enemy in hit)
        {
            enemy.transform.gameObject.SendMessage("GetHit", damage);
        }
    }
}
