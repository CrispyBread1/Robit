using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{

    // private  GameObject player;
    // rb = the bullet
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public Vector2 aim;
// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Bullet";
        aim.x = 153.23f;
        aim.y = 37f;

        
        
// this gives the bullet (rb) behaviour 
        rb.velocity = new Vector2(aim.x, (aim.y + 0.5f)).normalized * force;

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