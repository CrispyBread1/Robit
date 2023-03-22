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
    public Vector2 startingPosition;
    public bool canDrop;

    public float resetTimer;
    public bool startTimer;
    
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerInRange = 16f;
        rigidBody = GetComponent<Rigidbody2D>();
        randomDropTime = Random.Range(0f, 10f);
        collide = GetComponent<Collider2D>();
        startingPosition = transform.position;
        startTimer = false;
        canDrop = true;

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

        if (startTimer)
        {
            resetTimer += Time.deltaTime;
        }

        if (resetTimer >= 10)
        {
            reset();
        }

        if (canDrop)
        {
            timer += Time.deltaTime;
        }

        if (timer >= randomDropTime)
        {
            canDrop = false;
            drop();
        }

    }


    public void drop()
    {
        
        rigidBody.mass = 10.0f;
        rigidBody.WakeUp();
        
    }

    // public void OnCollisionENter2D(Collision2D collision)
    // {
    //     Debug.Log("i hit something");
    //     Destroy(gameObject);
    // }

    public void startResetTimer()
    {
        startTimer = true;
        
    }

    public void reset()
    {
        rigidBody.Sleep();
        transform.position = startingPosition;
        gameObject.tag = "FallingSpike";
        startTimer = false;
        resetTimer = 0;
        distanceToPlayer = 0;
        canDrop = true;
    }

    //  public void OnCollisionEnter2D(Collision2D collision)
    //  {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         reset();
    //     }
    //  }

}
