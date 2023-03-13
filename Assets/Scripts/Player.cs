using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    [SerializeField]private float speed;
    private Rigidbody2D playerBody;
    // private Animator animator;
    private bool isGrounded;
    [SerializeField]public float jumpSpeed = 10f;
    





    private void Start() {

        
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            isGrounded = false;
        }

    // Animation -
        // set animator to true or false
        // run name is equal to animation parameter in animation window
        // horizontal is 0 (false) = idle animation
        // animator.SetBool("run", HorizontalInput !=0);
    }

        public void OnCollisionEnter2D(Collision2D other)
        {
            // Check if the other object is a ground object
            if (other.gameObject.CompareTag("Ground"))
            {
                // Get the contact points between the player and the ground
                ContactPoint2D[] contacts = new ContactPoint2D[other.contactCount];
                other.GetContacts(contacts);

                // Check if any of the contact points are below the player
                for (int i = 0; i < contacts.Length; i++)
                {
                    if (contacts[i].point.y < transform.position.y)
                    {
                        isGrounded = true;
                        break;
                    }
                }
            }
}


}
