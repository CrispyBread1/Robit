using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int crystalValue = 5;

    public void OnTriggerEnter2D(Collider2D crystal)
    {
        if (crystal.gameObject.CompareTag("Player"))
        {   
            ;
            // calls the changescore function in scoremanager and passes the crystal value to it
            ScoreManager.instance.ChangeScore(crystalValue);
        }
        Destroy(gameObject);
        
    }

}
