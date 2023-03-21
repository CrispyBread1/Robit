using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth;
    public float timer;
    public int attackSpeed;
    private  EnemyCombat enemyCombat;
    public bool enemyHasDamagedAnimation = false;
    private bool dead = false;
    public bool isMeleeCombat;
    
    
    public void Start()
    {
        enemyCombat = GetComponent<EnemyCombat>();
        CurrentHealth = MaxHealth;
    }

    public void Update()
    {   
        if (isMeleeCombat)
        {
        timer += Time.deltaTime;
        }
        
    }


    public void attack()
    {
        if (timer > attackSpeed && isMeleeCombat)
        {
            enemyCombat.attack();
            resetTimer();
        }
    }



    public void resetTimer()
    {
        timer = 0f;
    }



// enemy takes damage
    public void takeDamage(int damage)
    {
        if (CurrentHealth > 0)
        {
            if(enemyHasDamagedAnimation)
            {
                enemyCombat.animator.SetTrigger("Damaged");
            }

            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                enemyDie();                
            }
        } else
        {
            // enemy has no health so dies
            enemyDie();
        }
        
    }



    public void enemyDie()
    {
// destroys all child compoinenents of the enemy
        while (transform.childCount > 0) 
        {
        DestroyImmediate(transform.GetChild(0).gameObject);
        }    

// triggers the damaged animation but also sets the dead bool to true so the enemy goes through the damaged animation and then the death animation
        dead = true;
        enemyCombat.animator.SetBool("Dead", dead);
        enemyCombat.animator.SetTrigger("Damaged");

        
    }



// this gets triggered from the end of the animation of when the enemy dies hoe
    public void destroyEnemy()
    {
        Destroy(gameObject);
    }

}
