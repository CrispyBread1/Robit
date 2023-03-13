using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public Rigidbody rigidBody;
    bool moveRight = false;
    bool moveLeft = false;
    // bool moveUp = false;
    // bool moveDown = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.D)){
            moveRight = true;
            
        } else if (Input.GetKeyUp(KeyCode.D)){
            moveRight = false;
        };

        if(Input.GetKeyDown(KeyCode.A)){
            moveLeft = true;
        } else if (Input.GetKeyUp(KeyCode.A)){
            moveLeft = false;
        };

        // if(Input.GetKeyDown(KeyCode.W)){
        //     moveUp = true;
        // } else if (Input.GetKeyUp(KeyCode.W)){
        //     moveUp = false;
        // };

        // if(Input.GetKeyDown(KeyCode.S)){
        //     moveDown = true;
        // } else if (Input.GetKeyUp(KeyCode.S)){
        //     moveDown = false;
        // };
    }

     private void FixedUpdate()
    {
        if (moveRight){
            rigidBody.AddForce(Vector3.right * 1, ForceMode.VelocityChange);
        }

        if(moveLeft){
            rigidBody.AddForce(Vector3.left * 1, ForceMode.VelocityChange);
        }

        // if(moveDown){
        //     rigidBody.AddForce(Vector3.back * 1, ForceMode.VelocityChange);
        // }

        // if(moveUp){
        //     rigidBody.AddForce(Vector3.forward * 1, ForceMode.VelocityChange);
        // }
    }
}
