using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPage : MonoBehaviour
{
    public TMP_Text massage;
    public Button navBtn;

    public void OpenTaskPage()
    {
        TaskList taskList = FindObjectOfType<TaskList>();
        Player player = FindObjectOfType<Player>();
        //as tast state 0 is not yet accepted any tast, state 1 is accepted tast[0]
        if(taskList.taskList.Length >= player.GetTastState() && player.GetTastState()!=0)
        {
            Task task = taskList.taskList[player.GetTastState()-1];
            massage.text = task.message;
            if (task.navPoint && task.navPoint.activeInHierarchy)
            {
                navBtn.gameObject.SetActive(true);
                Vector3 destination = task.navPoint.transform.position;
                navBtn.onClick.AddListener(() => player.SetNav(destination));
            }
        }
        else
        {
            massage.text = "";
        }
    }
}
