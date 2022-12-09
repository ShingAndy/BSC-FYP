using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskPage : MonoBehaviour
{
    public TMP_Text massage;

    public void OpenTaskPage()
    {
        TaskList taskList = FindObjectOfType<TaskList>();
        Player player = FindObjectOfType<Player>();
        if(taskList.taskList.Length >= player.GetTastState() && player.GetTastState()!=0)
        {
            Task task = taskList.taskList[player.GetTastState()-1];
            massage.text = task.message;
        }
        else
        {
            massage.text = "";
        }
    }
}
