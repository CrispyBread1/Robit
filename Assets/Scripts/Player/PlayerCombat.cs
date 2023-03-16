using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public bool canAttack;
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
            Attack();
            
        }
    }

        private void Attack()
    {
        //Play an attack animation
        if(canAttack)
        {
            animator.SetTrigger("attack");
            canAttack = false;
            
        }
        //detect enemies in range of attack
        // Physics2D.OverlapCircleAll();
        //damage them
    }
}
