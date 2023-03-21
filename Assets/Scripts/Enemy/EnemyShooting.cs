using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is the shooting/gun object class
public class EnemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPosition;
    public float timer;
    public float distance;
    private GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        // finding player potsition
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        // the distance in when the gun starts shooting 
        distance = Vector2.Distance(transform.position, player.transform.position);



        if (distance < 5)
        {
            // timer goes up in seconds
            timer += Time.deltaTime;

            // if timer is more than 2 seconds then timer will reet to 0
            if(timer > 2 )
            {
            timer = 0;
            Shoot();
            }
        }
    }

    void Shoot(){
        // this creats a new bullet object (bullet) when it shoots
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}
