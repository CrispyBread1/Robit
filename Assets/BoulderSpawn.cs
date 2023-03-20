// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BoulderSpawn : MonoBehaviour
// {

//     public float speed = 10.00f;
//     public float angle = 45f; // The angle of the hill in degrees
//     private Rigidbody2D rb;


//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = this.GetComponent<Rigidbody2D>();
//         float rad = angle * Mathf.Deg2Rad; // Convert angle to radians
//         Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)); // Calculate direction vector
//         rb.velocity = direction * speed;
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
