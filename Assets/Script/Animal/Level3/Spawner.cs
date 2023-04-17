using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;

    public GameObject objectToSpawn;
    public float spawnInterval = 1f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            Instantiate(objectToSpawn, spawnPoint1.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(objectToSpawn, spawnPoint2.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(objectToSpawn, spawnPoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);            
            Instantiate(objectToSpawn, spawnPoint4.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);            
            Instantiate(objectToSpawn, spawnPoint5.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Update()
    {

    }
}


