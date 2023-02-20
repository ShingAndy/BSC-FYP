using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerTurtle : MonoBehaviour
{
    public GameObject catchBtn;
    public GameObject catchBar;
    private GameObject player;

    //list of all turtle that can catch
    private List<GameObject> canCatch = new List<GameObject>();
    private GameObject closestTurtle;

    catchTurtleSystem catchTurtleSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //find the catch turtle system script
        catchTurtleSystem = FindObjectOfType<catchTurtleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //check any turtle can catch or not
        if (canCatch.Count > 0)
        {
            catchBtn.SetActive(true);
        }
        else
        {
            catchBtn.SetActive(false);
            catchBar.SetActive(false);
        }

        //player start catching the closest turtle but the turtle leave
        if(closestTurtle != null && !canCatch.Contains(closestTurtle))
        {
            closestTurtle.GetComponent<turtle>().catching(false);
            closestTurtle = null;
            catchTurtleSystem.setQuit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal")
        {
            //to show the green circle ui
            other.gameObject.GetComponent<turtle>().nearPlayer(true);
            if (!canCatch.Contains(other.gameObject)) { canCatch.Add(other.gameObject); }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "animal")
        {
            //to not show the green circle ui
            other.gameObject.GetComponent<turtle>().nearPlayer(false);
            canCatch.Remove(other.gameObject);
        }
    }

    //find the catching turtle by the cloest turtle
    public GameObject getCloestTurtle()
    {
        closestTurtle = canCatch[0];
        float dist = Vector3.Distance(player.transform.position, closestTurtle.transform.position);

        for (int i = 1; i< canCatch.Count; i++)
        {
            float newDist = Vector3.Distance(player.transform.position, canCatch[i].transform.position);
            if(dist > newDist)
            {
                closestTurtle = canCatch[i];
                dist = newDist;
            }
        }

        //set the turtle is catching
        closestTurtle.GetComponent<turtle>().catching(true);

        return closestTurtle;
    }

    public void playerStopCatching()
    {
        if(closestTurtle != null)
        {
            closestTurtle.GetComponent<turtle>().catching(false);
            closestTurtle = null;
        }
    }

    //when player catched the turtle
    public void destroyedTurtle(GameObject turtle)
    {
        canCatch.Remove(turtle);
    }
}
