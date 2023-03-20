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
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(boulderPrefab[Random.Range(0, boulderPrefab.Length)],
            position, Quaternion.identity);
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

