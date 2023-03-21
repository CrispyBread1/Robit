using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulders : MonoBehaviour
{
    public GameObject playerHealth;
    public Player player;
    public playerHealth health;



    // Start is called before the first frame update
    void Start()
    {   
        // find teh player object which is tagged Player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        // get player script
        player = playerObj.GetComponent<Player>();
        // get playerHealth script
        health = playerObj.GetComponent<playerHealth>();
}


    // Update is called once per frame
        public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            getHit(50);
            Debug.Log("collided");
    }
}
    public void getHit(float damage)
    {
        Debug.Log(damage);
        health.takeDamage(damage);
    }
}

