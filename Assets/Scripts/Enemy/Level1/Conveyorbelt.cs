using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyorbelt : MonoBehaviour
{

    public Animator animator;
    public float timer;
    public float spawnRate;
    public GameObject player;

    public float distanceToPlayer;

    public Transform rockSpawnPostion;
    public GameObject rock;
    public float playerInRange;

    public FishRockMonsterCreator fishRockMonsterCreator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);


        if (distanceToPlayer < playerInRange && timer >= spawnRate)
        {
            timer = 0f;
            animator.SetTrigger("StartRolling");
        }
    }

    public void spawnRock()
    {
        Instantiate(rock, rockSpawnPostion.position, Quaternion.identity);
        fishRockMonsterCreator.fire();
    }
}
