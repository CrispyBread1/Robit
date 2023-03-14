using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D playerBody;
    // private Animator animator;
    // private bool isJumping;
    // [SerializeField]private float jump;
    private bool isGrounded;
    [SerializeField]private float jumpSpeed = 10f;
    [SerializeField]private Health_Bar healthBar;
    
   

    private void Start() {

        healthBar.setSize(1f);
        isGrounded = true;
        playerBody = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
    }

    private void Update() {

        Physics.gravity = new Vector3(0, -120f, 0);

        float HorizontalInput = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(HorizontalInput * speed ,playerBody.velocity.y);

    // Flip the character if its numbers are looking at scales - 
        if(HorizontalInput >0.01f){
            transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        } else if(HorizontalInput < -0.01f){
            transform.localScale = new Vector3(-0.25f,0.25f,0.25f);
        }

    // Jump -
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                    isGrounded = false;
            }

    // when player runs out of health / dies
        if(healthBar.getHealth() == 0f)
        {
            die();
        }


    // Animation -
        // set animator to true or false
        // run name is equal to animation parameter in animation window
        // horizontal is 0 (false) = idle animation
        // animator.SetBool("run", HorizontalInput !=0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("am inside the on colllision");

        if (other.gameObject.tag == "Floor" && isGrounded == false)
        {
            isGrounded = true;
        }

    // if collided with enemy pass through a certain value to take health down by
        if (other.gameObject.tag == "EnemyHit")
        {
            if(healthBar.getHealth() != 0f)
            {
                healthBar.getHit(0.25f);
            }
            
        }
    }

    public void die()
    {
        
    }


}
