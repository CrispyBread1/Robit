using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRoomFloor : MonoBehaviour
{

    

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "FallingSpike")
        {
            Destroy(collision.gameObject);
            
        }
       
    }

    

}