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

        float HorizontalInput = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(HorizontalInput * speed ,playerBody.velocity.y);

    // Flip the character if its numbers are looking at scales - 
        if(HorizontalInput >0.01f){
            transform.localScale = new Vector3(6f,6f,6f);
        } else if(HorizontalInput < -0.01f){
            transform.localScale = new Vector3(-6f,6f,6f);
        }

    // Jump -
        // 



        if (Input.GetKey(KeyCode.Space) && JumpAmount == 1)
        // if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump(); 
        }

    // Animation -
        // set animator to true or false
        // run name is equal to animation parameter in animation window
        // horizontal is 0 (false) = idle animation
        animator.SetBool("run", HorizontalInput !=0);
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

    // if collided with enemy pass through a certain value to take health down by
    }

    public void getHit(float damage)
    {
        // Debug.Log(damage);
        playerHealth.takeDamage(damage);
    }

// function to add the score of the crystal and destroy it 
    public void OnTriggerEnter2D(Collider2D crystal)
    {

        if (crystal.gameObject.CompareTag("Crystal"))
        {   
            ScoreManager.instance.ChangeScore(crystalValue);
            // StartCoroutine(DestroyCrystalAfterDelay(crystal.gameObject, 1.0f));
            Destroy(crystal.gameObject);
        }

    }
    // private IEnumerator DestroyCrystalAfterDelay(GameObject crystal, float delay)
    // {
    //     // Wait for the specified delay duration
    //     yield return new WaitForSeconds(delay);

    //     // Destroy the crystal after the delay
    //     Destroy(crystal);
    // }

}
