using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyGunFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public float timer;
    public float distance;
    // public Enemy enemy;
    private GameObject player;
    public Animator animator;
    public float fireRate;
    public EnemyMovement enemyMovement;
    // public Enemy enemy;


    private float rotationSpeed = 20f;

    public float rotationModifier;

    public float distanceToPlayer;



    
    void Start()
    {
// finding player potsition
        player = GameObject.FindGameObjectWithTag("Player");
        // enemyMovement = GetComponent<EnemyMovement>();
    }

    
    void Update()
    {   
// the distance in when the gun starts shooting 
        distance = Vector2.Distance(transform.position, player.transform.position);

// timer goes up in seconds
        timer += Time.deltaTime;

// if timer is more than 2 seconds then timer will reet to 0
        if( timer > fireRate && enemyMovement.attackRange >= distance)
        {
        timer = 0;
        animator.SetTrigger("Fire");
        } 

       
// This flips the guns rotation so it is mirrored on each side of the enemy, depending on players positiion
        

        // Quaternion rotation = Quaternion.LookRotation (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        // transform.rotation = new Quaternion(0, 0, 0, rotation.w);

        
    }

    private void changeGunDirection()
    {

        distanceToPlayer = player.transform.position.x - transform.position.x;
        
        if (distanceToPlayer <= 0.01f)
        {
            // Debug.Log("Left side");
            rotationModifier = 180f;
        } else if (distanceToPlayer >= -0.01f)
        { 
            // Debug.Log("right side");

            rotationModifier = 360f;
        }
    }

    private void Shoot(){
// this creats a new bullet object (bullet) when it shoots
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        changeGunDirection();

        if (player != null && enemyMovement.attackRange >= distance)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }

    }

    private void stopMovingWhileFiring()
    {
        enemyMovement.stopMoving();
    }

    private void startMovingAfterFiring()
    {
        enemyMovement.startMoving();
    }

    
}
