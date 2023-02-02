using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rhino : CatchAnimal
{
    public GameObject arrowGroup;

    public void DestroyObject()
    {
        Destroy(arrowGroup);
        gameObject.tag = "Untagged";
        circleUi.SetActive(false);
    }
}
