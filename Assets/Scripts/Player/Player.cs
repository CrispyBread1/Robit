using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D playerBody;

    // private bool isJumping;

    // [SerializeField]private float jump;
    private bool isGrounded;
    [SerializeField]private float jumpSpeed = 10f;

    // private Level1Manager levelManager;
    private RespawnScript respawnScript;
    private Animator animator;
    private playerHealth playerHealth;
    public int crystalValue = 5;
    private int JumpAmount;
    private bool canMove = true;


    private void Start() {

        playerHealth = GetComponent<playerHealth>();
        respawnScript = GetComponent<RespawnScript>();
        playerBody = GetComponent<Rigidbody2D>();
        isGrounded = true;
        animator = GetComponent<Animator>();

        JumpAmount = 1;
    }

    private void Update() {

        Physics.gravity = new Vector3(0, -120f, 0);

        
        // if(canMove)
        // {

            float HorizontalInput = Input.GetAxis("Horizontal");

            playerBody.velocity = new Vector2(HorizontalInput * speed ,playerBody.velocity.y);

 // Flip the character if its numbers are looking at scales - 
            if(HorizontalInput >0.01f && gameObject != null){
                transform.localScale = new Vector3(6f,6f,6f);
            } else if(HorizontalInput < -0.01f){
                transform.localScale = new Vector3(-6f,6f,6f);
            }

            animator.SetBool("run", HorizontalInput !=0);
        // }

   

    // Jump -
        if (Input.GetKey(KeyCode.Space) && JumpAmount == 1)
        // if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump(); 
        }

    // Animation -
        // set animator to true or false
        // run name is equal to animation parameter in animation window
        // horizontal is 0 (false) = idle animation
        
        animator.SetBool("grounded", isGrounded);
    }

    private void Jump(){
        JumpAmount = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("am inside the on colllision");

        if (collision.gameObject.tag == "Floor" && isGrounded == false)
        {
            JumpAmount = 1;
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            getHit(15);
        }
        if (collision.gameObject.tag == "lava"){
            getHit(50);
        }
 
        if (collision.gameObject.tag == "mace"){
            getHit(25);

        if (collision.gameObject.tag == "Spikes")
        {
            getHit(100);
        }
        if (collision.gameObject.tag == "FallingSpike")
        {
            Destroy(collision.gameObject);
            getHit(50);


        }

    // if collided with enemy pass through a certain value to take health down by
    }

    public void getHit(float damage)
    {
        // Debug.Log(damage);
        playerHealth.takeDamage(damage);
    }

    // private IEnumerator DestroyCrystalAfterDelay(GameObject crystal, float delay)
    // {
    //     // Wait for the specified delay duration
    //     yield return new WaitForSeconds(delay);

    //     // Destroy the crystal after the delay
    //     Destroy(crystal);
    // }

    // public void startMoving()
    // {
    //     canMove = true;
    // }

    // public void stopMoving()
    // {
    //     canMove = false;
    // }
}
