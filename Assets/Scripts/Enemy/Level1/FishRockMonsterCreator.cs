using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRockMonsterCreator : MonoBehaviour
{


    public GameObject rock;

     public GameObject bullet;
    public Transform bulletPosition;
    public float timer;
    
    // public Enemy enemy;
    private GameObject player;
    public Animator animator;
    public float fireRate;
    public float attackRange = 10f;
    
    // public Enemy enemy;


    private float rotationSpeed = 20f;

    public float rotationModifier = 180f;

    public float distanceToRock;



    
    void Start()
    {
// finding player potsition
        player = GameObject.FindGameObjectWithTag("Player");
        // enemyMovement = GetComponent<EnemyMovement>();
    }

    
    void Update()
    {   

        rock = GameObject.FindGameObjectWithTag("Rock");
// the distance in when the gun starts shooting 
        distanceToRock = Vector2.Distance(transform.position, rock.transform.position);

// timer goes up in seconds
        timer += Time.deltaTime;

// if timer is more than 2 seconds then timer will reet to 0
        if( timer > fireRate && attackRange >= distanceToRock)
        {
        timer = 0;
        animator.SetTrigger("Fire");
        } 
        
    }

    public void findRock()
    {
      while(rock == null)
      {
        rock = GameObject.FindGameObjectWithTag("Rock");
      }   
    }

    

    private void Shoot(){
// this creats a new bullet object (bullet) when it shoots
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }



    private void FixedUpdate()
    {
        
        if (rock != null && attackRange >= distanceToRock)
        {
            Vector3 vectorToTarget = rock.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }

    }

    
    
}
