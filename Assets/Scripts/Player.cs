using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D playerBody;
    // private Animator animator;
   
// awake called everytime the scipt loads
    private void Start() {
        playerBody = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
    }

    private void Update() {
        float HorizontalInput = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(HorizontalInput * speed ,playerBody.velocity.y);

    // Flip the character if its numbers are looking at scales
        if(HorizontalInput >0.01f){
            transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        } else if(HorizontalInput < -0.01f){
            transform.localScale = new Vector3(-0.25f,0.25f,0.25f);
        }
        if(Input.GetKey(KeyCode.Space)){
            playerBody.velocity = new Vector2(playerBody.velocity.x, speed);
        }

        // set animator to true or false
        // run name is equal to animation parameter in animation window
        // horizontal is 0 (false) = idle animation
        // animator.SetBool("run", HorizontalInput !=0);
        
    }

    

}
