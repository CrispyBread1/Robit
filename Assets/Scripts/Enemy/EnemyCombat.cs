using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    private bool canAttack;
    public LayerMask playerLayers;
    

    
    // private Enemy enemy;
    


    

    void Start()
    {

    }


    void Update()
    {
        
    }

    
    public void attack()
    {
        canAttack = true;
        MeleeAttack();
    }

    private void MeleeAttack()
    {
//Play an attack animation
        // if(canAttack)
        // {
            animator.SetTrigger("Attack");
            
            
// detect enemies in range of attack
// this adda an invisible sphere around our attack point and it will give it a range we decide             
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            // Debug.Log(hitPlayer[0]);

            foreach (Collider2D player in hitPlayer)
//damage them
            {
            player.GetComponent<Player>().getHit(25);
            }

            // canAttack = false;
        // }

        
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
