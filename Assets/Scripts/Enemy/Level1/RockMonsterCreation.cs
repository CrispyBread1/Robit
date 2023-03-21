using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMonsterCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
        
    }
}
