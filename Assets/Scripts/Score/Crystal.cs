using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int crystalValue = 5;
    public int megaCrystalValue = 15;

    public void OnTriggerEnter2D(Collider2D crystal)
    {
        if (crystal.gameObject.CompareTag("Crystal"))
        {   
            Debug.Log("Crystal");
            // calls the changescore function in scoremanager and passes the crystal value to it
            ScoreManager.instance.ChangeScore(crystalValue);
        } else if (crystal.gameObject.CompareTag("MegaCrystal")){
            Debug.Log("MegaCrystal");
            ScoreManager.instance.ChangeScore(megaCrystalValue);
        }
        
    }

}
