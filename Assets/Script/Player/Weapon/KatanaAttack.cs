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
    [SerializeField] AudioSource swingSound;
    bool cooling = false;
    SwitchWeapon switchScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        switchScript=transform.parent.parent.parent.GetComponent<SwitchWeapon>();
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

        // need to add enabling katana condition for its special disable mechanic
        if (!isGrappling && Input.GetMouseButtonDown(0)&&!cooling&&switchScript.enablingKatana)
        {
            if (!swingSound.isPlaying)
            {
                swingSound.Play();
            }
            animator.SetBool("isAttack", true);

            // cooling for one second
            cooling = true;
            StartCoroutine(waitForCooling());
        }
    }

    // added cooling because audio couldn't finish
    IEnumerator waitForCooling()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        cooling = false;
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
