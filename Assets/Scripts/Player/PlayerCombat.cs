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
    public bool wontAttack = true;
    public float attackSpeed = 1f;
    public float timer;


    
// Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attackPoint = GameObject.FindGameObjectWithTag("PlayerAttackPoint").transform;
        
    }

// Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        
            if (Input.GetKeyDown(KeyCode.J))
            {   

                canAttack = true;
                MeleeAttack();

                
            }
        
        
    }

    private void MeleeAttack()
    {
//Play an attack animation
        if(canAttack && timer >= attackSpeed)
        {

            canAttack = false;
            animator.SetTrigger("attack");
            
            timer = 0;
// detect enemies in range of attack
// this adda an invisible sphere around our attack point and it will give it a range we decide             
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // Debug.Log(hitEnemies[0]);
            foreach (Collider2D enemy in hitEnemies)
//damage them
            {
                if(enemy.transform.gameObject.tag == "FallenSpike")
                {
                    enemy.transform.GetComponent<Spikes>().reset();
                }

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

    // private void allowAttack()
    // {
    //     wontAttack = true;
    // }

    // private void cantAttack()
    // {
    //     wontAttack = false;
    // }


}
