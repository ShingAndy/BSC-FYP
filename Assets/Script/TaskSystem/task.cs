using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class task
{
    public string name;

    [TextArea(3, 10)]
    public string message;

    public GameObject navPoint;

    public int money;

    private bool isFinished = false;

    public void FinishedTask()
    {
        isFinished = true;
    }
}
