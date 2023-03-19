using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyGunFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public float timer;
    public float distance;
    private GameObject player;
    public Animator animator;




    
    void Start()
    {
// finding player potsition
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {   
// the distance in when the gun starts shooting 
        distance = Vector2.Distance(transform.position, player.transform.position);

// timer goes up in seconds
        timer += Time.deltaTime;

// if timer is more than 2 seconds then timer will reet to 0
        if( timer > 5 )
        {
        timer = 0;
        animator.SetTrigger("Fire");
        } 
        
    }

    private void Shoot(){
// this creats a new bullet object (bullet) when it shoots
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}
