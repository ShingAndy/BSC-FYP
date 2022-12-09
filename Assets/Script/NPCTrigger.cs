using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject dialogueStart;
    public GameObject task;
    public GameObject tastStart;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dialogue.SetActive(true);
            dialogueStart.SetActive(true);
            if (task)
            {
                Player player = FindObjectOfType<Player>();
                int tastFinished = player.GetTastState();
                //if the player already finish or get the task
                if (task.GetComponentInChildren<TaskManager>().taskOrder <= tastFinished)
                    return;
                task.SetActive(true);
                tastStart.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogue.SetActive(false);
            dialogueStart.SetActive(false);
            if (task)
            {
                task.SetActive(false);
                tastStart.SetActive(false);
            }
        }
    }
}
