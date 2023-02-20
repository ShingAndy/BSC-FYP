using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject dialogueStart;
    public GameObject task;
    public GameObject tastStart;
    public GameObject haveTaskIcon;
    private Player player;
    private bool haveTask = false;
    private int tastFinished;
    private TaskList taskList;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        taskList = FindObjectOfType<TaskList>();
    }

    private void Update()
    {
        CheckHaveTask();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dialogue.SetActive(true);
            dialogueStart.SetActive(true);
            if (task && haveTask && task.GetComponentInChildren<TaskManager>().taskOrder == tastFinished + 1)
            {
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

    private void CheckHaveTask()
    {
        tastFinished = player.GetTastState();
        //if the player can get the task or the task is to find this npc
        if (task.GetComponentInChildren<TaskManager>().taskOrder == tastFinished + 1 ||
            (tastFinished != 0 && taskList.taskList.Length >= tastFinished && taskList.taskList[tastFinished - 1].navPoint == gameObject))
        {
            haveTaskIcon.SetActive(true);
            haveTask = true;
        }
        else
        {
            haveTaskIcon.SetActive(false);
            haveTask = false;
        }
    }
}
