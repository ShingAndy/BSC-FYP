using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenNav : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;

    public float speed = 3f;
    public float range;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;


    }

    void Update()
    {
        playerTransform = GameObject.Find("Player").transform;

        //get chicken and player distance
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log(distance);

        //follow player
        if (distance < range)
        {
            agent.SetDestination(playerTransform.position);
        }

        //stop when too close
        if (distance > agent.stoppingDistance)
        {
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
    }
}
