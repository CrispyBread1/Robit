using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCrystal : MonoBehaviour
{
    public int megaCrystalValue = 15;

    public void OnTriggerEnter2D(Collider2D crystal)
    {
        if (crystal.gameObject.CompareTag("Player"))
        {   
            ;
            // calls the changescore function in scoremanager and passes the megacrystal value to it
            Debug.Log("MegaCrystal");
            ScoreManager.instance.ChangeScore(megaCrystalValue);
        }
        Destroy(gameObject);
        
    }

}