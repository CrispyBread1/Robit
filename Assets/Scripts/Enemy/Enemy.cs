using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;

    private float distance;
    public float xDistance;
    private float xMovement;
    public float distanceChase;

    public int MaxHealth = 100;
    public int CurrentHealth;
    public float timer;

    public int attackSpeed;
    
    public  EnemyCombat enemyCombat;
    private bool allowedToMove = true;

    // Start is called before the first frame update
    public void Start()
    {
        CurrentHealth = MaxHealth;

    }

    // Update is called once per frame
    public void Update()
    {   
        timer += Time.deltaTime;
        // if (CurrentHealth <= 0)
        // {
        //     enemyDie();
        // }
        // transform.postion is the position of the object and player.transform.position is the position of the player
        // distance = Vector2.Distance(transform.position, player.transform.position);
        // direction now equals to one object following the other
        // Vector2 direction = player.transform.position - transform.position;

        // Calculate the movement vector by setting its y-component to 0 and its x-component to the desired speed
        // Vector2 movement = new Vector2(Mathf.Sign(direction.x) * speed, 0f);

        // this now assigns tranform.positon to the enemy to follow the player at a certain speed
        // transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        // calculates the  X distance between the enemy and the player
        xDistance = player.transform.position.x - transform.position.x;

        //  X movement needed to reach the player at the wanted speed
        xMovement = Mathf.Sign(xDistance) * speed * Time.deltaTime;


        if (xDistance < distanceChase && allowedToMove){
        // movement vector that only moves in the X direction
        Vector2 movement = new Vector2(xMovement, 0f);

        // Move the enemy towards the player using the movement vector
        transform.position += (Vector3)movement;

        
        attack();
        
        }

        if(xDistance < 0.01f){
            transform.localScale = new Vector3(6f,6f,6f);
        } else if(xDistance > -0.01f){
            transform.localScale = new Vector3(-6f,6f,6f);
        }
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
//  add an animation to take damage
//          -----------------------
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
        // add die animation
        enemyCombat.animator.SetTrigger("Dead");
        // 
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }


// stops the enemy moving while dieing
    public void stopMoving()
    {
        allowedToMove = false;
    }

    }
