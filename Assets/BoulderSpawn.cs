using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is the bullet class
public class BoulderSpawn : MonoBehaviour
{

    private  GameObject player;
    // rb = the bullet
    private Rigidbody2D rb;
    public float force;
    public float timer;

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Boulder";
//used to give the coordinates of the player
        player = GameObject.FindGameObjectWithTag("Player");

        

// used to find the position of the player
        Vector2 direction = player.transform.position - transform.position;
// this gives the bullet (rb) behaviour 
        rb.velocity = new Vector2(direction.x, (direction.y + 1.5f)).normalized * force;

    }

    // Update is called once per frame
    void Update()
    {
// timer doesnt count by itself, It counts the frames and convertis into time. Thats why we += 
// This is the bullets own timer
        timer += Time.deltaTime;

// If timer is at a certain time it breaks.
        if(timer > 5){
            Destroy(gameObject);
        }
            
        
    }

// when bullet hits player
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // if(collision.gameObject.tag == "Player")
        // {
            
            Destroy(gameObject);
            
            

        // }
    }
    
}







// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BoulderSpawn : MonoBehaviour
// {

//     public float speed = 10.00f;
//     public float angle = 45f; // The angle of the hill in degrees
//     private Rigidbody2D rb;


//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = this.GetComponent<Rigidbody2D>();
//         float rad = angle * Mathf.Deg2Rad; // Convert angle to radians
//         Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)); // Calculate direction vector
//         rb.velocity = direction * speed;
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
