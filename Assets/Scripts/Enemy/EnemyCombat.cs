using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public bool canAttack = false;
    public LayerMask playerLayers;
    public int enemyDamage;
    
    Collider2D[] hitPlayers;

    
    // private Enemy enemy;

    void Start()
    {
        animator = GetComponent<Animator>();
        attackPoint = transform.Find("AttackPoint");

    }


    void Update()
    {
       
        // Debug.Log(hitPlayers[0]);
    }

    
    public void attack()
    {
        canAttack = true;
        MeleeAttack();
    }

    private void MeleeAttack()
    {

        animator.SetTrigger("Attack");
    
// detect enemies in range of attack
// this adda an invisible sphere around our attack point and it will give it a range we decide 
        

        // while(hitPlayers.Length = 0)
        // {
            
        //     Debug.Log(hitPlayers[0] + "In the hit player");
        // }

        if (canAttack)
        {
            // Unity method used to find all the colliders that overlap with a circular area in 2D space.
            hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        
        foreach (Collider2D player in hitPlayers)

        {
                //damage them
                player.GetComponent<Player>().getHit(enemyDamage);
                canAttack = false;
        }
        }
        


        
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
