using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isladder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isladder && Mathf.Abs(vertical) > 0f){
            isClimbing = true;
        }
    }

    private void FixedUpdate() {
        if(isClimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed );
        }
        else
        {
            rb.gravityScale = 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            isladder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            isladder = false;
            isClimbing = false;
        }
    }
}
