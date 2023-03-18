using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int MaxHealth = 100;
    public int CurrentHealth;
    private float timer;
    public int attackSpeed;
    private  EnemyCombat enemyCombat;
    public bool enemyHasDamagedAnimation = false;
    private bool dead = false;
    
    
    public void Start()
    {
        
        enemyCombat = GetComponent<EnemyCombat>();
        CurrentHealth = MaxHealth;

    }

    
    public void Update()
    {   

        timer += Time.deltaTime;
        
    }



    public void attack()
    {
        if (timer > attackSpeed)
        {
            enemyCombat.attack();
            resetTimer();
        }
    }



    public void resetTimer()
    {
        timer = 0;
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
        dead = true;
        enemyCombat.animator.SetBool("Dead", dead);
        enemyCombat.animator.SetTrigger("Damaged");
    }



// this gets triggered from the end of the animation of when the enemy dies hoe
    public void destroyEnemy()
    {
        Destroy(gameObject);
    }



// stops the enemy moving while dieing
   
}
