using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] boulderPrefab;
    [SerializeField] float secondBoulder;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;



    void Start()
    {
        StartCoroutine(BoulderSpawns());
    }

    // IEnumerator is a coroutine (coroutine is a function that allows you to pause an execition and pick it back up at any poit) that runs the code while true
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
}


