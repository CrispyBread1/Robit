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
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        health = playerObj.GetComponent<playerHealth>();
}


    // Update is called once per frame
        public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            getHit(100);
            Debug.Log("collided");
    }
}
    public void getHit(float damage)
    {
        Debug.Log(damage);
        health.takeDamage(damage);
    }
}

