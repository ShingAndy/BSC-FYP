using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public string name;

    [TextArea(3, 10)]
    public string message;

    public GameObject navPoint;

    public int money;

    //public int level;
}
