using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRoomFloor : MonoBehaviour
{

    
    

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "FallingSpike")
        {

            collision.gameObject.tag = "FallenSpike";
            collision.transform.GetComponent<Spikes>().startResetTimer();
            
            
        }
       
    }

    

}