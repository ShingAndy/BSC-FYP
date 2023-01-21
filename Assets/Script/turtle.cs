using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    public GameObject circleUi;
    //catchTurtleSystem catchTurtleSystem;

    // Start is called before the first frame update
    void Start()
    {
        //catchTurtleSystem = FindObjectOfType<catchTurtleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        circleUi.SetActive(true);
    //        catchTurtleSystem.setCanCatch(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        circleUi.SetActive(false);
    //        catchTurtleSystem.setCanCatch(false);
    //    }
    //}

    public void nearPlayer(bool yes)
    {
        if(yes)
            circleUi.SetActive(true);
        else
            circleUi.SetActive(false);
    }
}
