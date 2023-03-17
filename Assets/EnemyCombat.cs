using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    private bool canAttack;
    public LayerMask enemyLayers;
    public float timer;
    


    

    void Start()
    {

    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {   
            canAttack = true;
            MeleeAttack();
            
        } 
    }


    private void MeleeAttack()
    {
//Play an attack animation
        if(canAttack)
        {
            animator.SetBool("CanAttack", canAttack);
            canAttack = false;
            
// detect enemies in range of attack
// this adda an invisible sphere around our attack point and it will give it a range we decide             
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D player in hitPlayer)
//damage them
            {
            player.GetComponent<Player>().getHit(25);
            }
        }

        timer += 0;
    }

    
//  so we can see the range of the attack point
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }


}
