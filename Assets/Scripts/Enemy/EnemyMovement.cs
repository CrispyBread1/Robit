using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    // private float distance;
    public float xDistance;
    private float xMovement;
    public float stepSize;
    public float StepTimer;

    public float distanceChase;

    // private bool inAttackRange = false;
    public float attackRange;

    private bool allowedToMove = true;

    public float ScaleOfEnemy;

    private Animator animator;
    public bool hasRunningAnimation;
  
    private  EnemyCombat enemyCombat;

    public float startingPostionX;

    private Enemy enemy;

    
    void Start()
    {

        // player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
        enemyCombat = GetComponent<EnemyCombat>();
        stepSize = ScaleOfEnemy / 100;
        animator = GetComponent<Animator>();
        startingPostionX = transform.position.x;
        
    }

    
    void Update()
    {
        
        StepTimer += Time.deltaTime;

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
        
        
        
        if (xDistance < distanceChase && allowedToMove && StepTimer >= ScaleOfEnemy / 10f){
        // movement vector that only moves in the X directio
        // Move the enemy towards the player using the movement vector
        takeAStep(stepSize);
        enemy.attack();
        
        }
// if movemtn has swtich sides the steps direction will too
        if(xDistance >= 0.1f && StepTimer >= ScaleOfEnemy / 100f){
            transform.localScale = new Vector3(ScaleOfEnemy,ScaleOfEnemy,ScaleOfEnemy);
            stepSize = stepSize * 1f;
        }
        if(xDistance >= -0.01f && StepTimer >= ScaleOfEnemy / 100f){
            transform.localScale = new Vector3(-ScaleOfEnemy,ScaleOfEnemy,ScaleOfEnemy);
            stepSize = stepSize * -1f;
        }

// gets the starig postion of the enemy, and if its moving the postion will change and thus the anitmaion runs if its moving
        if (hasRunningAnimation)
        {
            if (transform.position.x > startingPostionX || transform.position.x < startingPostionX)
            {
                animator.SetBool("run", true);
                
            }
        }

        if (xDistance == attackRange || xDistance == attackRange)
        {
            enemyCombat.attack();
            stopMoving();
        }

    }

    public void takeAStep(float step)
    {
        step += startingPostionX;
        Vector2 movement = new Vector2(step, 0f);
        // Move the enemy towards the player using the movement vector
        transform.position += (Vector3)movement;
        StepTimer = 0f;
    }
     public void stopMoving()
    {
        allowedToMove = false;
    }

    public void startMoving()
    {
        allowedToMove = true;
    }

    public void changeDirection(float direction)
    {
        Debug.Log(direction);
        stepSize = direction;
    }

}
