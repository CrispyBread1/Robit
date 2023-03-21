using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMonsterCreation : MonoBehaviour
{

    public GameObject rockMonster;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // Instantiate(rockMonster, bulletPosition.position, Quaternion.identity);

            Destroy(gameObject);
        }
        
    }
}
