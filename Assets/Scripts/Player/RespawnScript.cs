using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    private Transform currentCheckpoint;
    private playerHealth healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
    }
}
