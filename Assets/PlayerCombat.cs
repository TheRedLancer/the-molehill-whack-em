using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform APD;
    public Transform APU;
    public Transform APL;
    public Transform APR;

    public float atkRange = 0.5f;
    public LayerMask enemyLayers;

    public int atkDmg = 1;

    public float atkRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("AttackDown"))
            {
                AttackDown();
                nextAttackTime = Time.time + 1f / atkRate;
            }
            if (Input.GetButtonDown("AttackUp"))
            {
                AttackUp();
                nextAttackTime = Time.time + 1f / atkRate;
            }
            if (Input.GetButtonDown("AttackLeft"))
            {
                AttackLeft();
                nextAttackTime = Time.time + 1f / atkRate;
            }
            if (Input.GetButtonDown("AttackRight"))
            {
                AttackRight();
                nextAttackTime = Time.time + 1f / atkRate;
            }
        }
    }

    void AttackDown()
    {
        //animate
        animator.SetTrigger("AttackDown");
        animator.SetFloat("Vertical", -1f);

        damageEnemies(APD);

    }
    void AttackUp()
    {
        //animate
        animator.SetTrigger("AttackUp");
        animator.SetFloat("Vertical", 1f);

        damageEnemies(APU);

    }
    void AttackLeft()
    {
        //animate
        animator.SetTrigger("AttackLeft");
        animator.SetFloat("Horizontal", -1f);

        damageEnemies(APL);

    }
    void AttackRight()
    {
        //animate
        animator.SetTrigger("AttackRight");
        animator.SetFloat("Horizontal", 1f);

        damageEnemies(APR);
        
    }

    private void OnDrawGizmosSelected()
    {
        if (APU == null || APD == null || APL == null || APR == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(APU.position, atkRange);
        Gizmos.DrawWireSphere(APD.position, atkRange);
        Gizmos.DrawWireSphere(APR.position, atkRange);
        Gizmos.DrawWireSphere(APL.position, atkRange);

    }
    
    void damageEnemies(Transform AP)
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AP.position, atkRange, enemyLayers);
        //damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(atkDmg);
        }
    }

}
