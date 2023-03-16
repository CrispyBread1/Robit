using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    private bool canAttack;
    public LayerMask enemyLayers;


    
// Start is called before the first frame update
    void Start()
    {
       
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
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
            animator.SetTrigger("attack");
            canAttack = false;
            
// detect enemies in range of attack
// this adda an invisible sphere around our attack point and it will give it a range we decide             
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
//damage them
            {
            enemy.GetComponent<Enemy>().takeDamage(50);
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
