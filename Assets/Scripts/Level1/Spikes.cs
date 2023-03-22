using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public float timer;
    public GameObject player;
    public float distanceToPlayer;
    public float playerInRange;
    public float randomDropTime;
    private Rigidbody2D rigidBody;
    public Collider2D collide;
    
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerInRange = 1f;
        rigidBody = GetComponent<Rigidbody2D>();
        randomDropTime = Random.Range(0f, 20f);
        collide = GetComponent<Collider2D>();

    }

   
    void Update()
    {

        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        // distanceToPlayer =  transform.position - player.transform.position;

        // Debug.Log(distanceToPlayer);

        if (distanceToPlayer < playerInRange)
        {
            drop();
        }

        // if (transform.position.y >= player.transform.position.y)
        // {
        //     gameObject.tag = "Untagged";
        // }

    }


    public void drop()
    {

        while(timer <= randomDropTime)
        {
            timer += Time.deltaTime;
        } 
        
        if(timer >= randomDropTime)
        {
            rigidBody.mass = 10.0f;
            rigidBody.WakeUp();
        }
        
    }

    // public void OnCollisionENter2D(Collision2D collision)
    // {
    //     Debug.Log("i hit something");
    //     Destroy(gameObject);
    // }

    

}
