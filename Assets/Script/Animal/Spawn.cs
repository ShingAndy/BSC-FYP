using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject animal;
    public int time;

    void Start()
    {
        StartCoroutine(SpawnAnimal());
    }

    void Update()
    {
    }

    IEnumerator SpawnAnimal()
    {
        while(true)
        {
            Vector3 pos;
            pos.x = Random.Range(-15, 15);
            pos.y = 3;
            pos.z = Random.Range(-11, 11);

            Instantiate(animal, pos, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
