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
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                    isGrounded = false;
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
            // Debug.Log("am inside the on colllision");
            isGrounded = true;
        }
    }


    // public void OnCollisionEnter(Collision collision)
    // {
    //     isGrounded = true;
    //     Debug.Log("i have collided with ground");
    // }

    // public void OnCollisionExit(Collision collision)
    // {
    //     isGrounded = false;
    // }

}
