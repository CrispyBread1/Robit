using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] boulderPrefab;
    [SerializeField] float secondBoulder;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    private playerHealth playerHealth;



    void Start()
    {
        StartCoroutine(BoulderSpawns());
    }

    IEnumerator BoulderSpawns()
    {
        while (true)
        {   
            // creates a random float between minTras and maxTras and sets to wanted
            var wanted = Random.Range(minTras, maxTras);
            // creates a new vector3 of where the boulder will spawn
            var position = new Vector3(wanted, transform.position.y);
            // this creates a new object based on the boulder prefab, it generates a random boulder from the boulder list
            // using the postion variable and boulder orientation
            GameObject gameObject = Instantiate(boulderPrefab[Random.Range(0, boulderPrefab.Length)],
            position, Quaternion.identity);
            // yield asks to wait a specific time before retunring the second boulder 
            yield return new WaitForSeconds(secondBoulder);
            
            Destroy(gameObject);
            
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            getHit(100);
    }
}
    public void getHit(float damage)
    {
        Debug.Log(damage);
        playerHealth.takeDamage(damage);
    }
}

//     public Transform spawnBoulder;
//     public GameObject boulder;
//     public bool isTimer;
//     public float timeToSpawn;
//     private float currentTimeToSpawn;


//     // Start is called before the first frame update
//     void Start()
//     {
//         currentTimeToSpawn = timeToSpawn;
//     }

//     // Update is called once per frame
//     void Update()
//     {   
//         if(isTimer){
//         UpdateTimer();
//         }
//     }

//     public void UpdateTimer()
//     {
//         if(currentTimeToSpawn > 0){
//             currentTimeToSpawn -= Time.deltaTime;
//         }
//         else {
//             SpawnObject();
//             currentTimeToSpawn = timeToSpawn;
//         }
//     }

//     public void SpawnObject(){
//         Instantiate(boulder, transform.position, transform.rotation);
//     }
// }

