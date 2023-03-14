using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is the bullet class
public class EnemyBulletScript : MonoBehaviour
{

    private  GameObject player;
    // rb = the bullet
    private Rigidbody2D rb;
    public float force;
    private float timer;






    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //used to give the coordinates of the player
        player = GameObject.FindGameObjectWithTag("Player");

        // used to find the position of the player
        Vector2 direction = player.transform.position - transform.position;
        // this gives the bullet (rb) behaviour 
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if(timer > 6)
        {
            Destroy(rb);
        }
    }

    //when bullet hits player
    public void OnBulletHitPlayer(Collider2D hit)
    {
        if(hit.gameObject.CompareTag("Player"))
        {
            Destroy(rb);
        }
    }
}
