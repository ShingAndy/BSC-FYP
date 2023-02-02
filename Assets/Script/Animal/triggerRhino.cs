using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerRhino : MonoBehaviour
{
    public GameObject catchBtn;
    public GameObject catchBar;
    private GameObject player;

    //same all Rhino that can catch
    private List<GameObject> canCatch = new List<GameObject>();
    private GameObject closestTurtle;

    savingRhinoSystem savingRhinoSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //find the catch Rhino system script
        savingRhinoSystem = FindObjectOfType<savingRhinoSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //check any Rhino can catch or not
        if (canCatch.Count > 0)
        {
            catchBtn.SetActive(true);
        }
        else
        {
            catchBtn.SetActive(false);
            catchBar.SetActive(false);
        }

        //player start catching the closest Rhino but the Rhino leave
        if(closestTurtle != null && !canCatch.Contains(closestTurtle))
        {
            closestTurtle.GetComponent<Rhino>().catching(false);
            closestTurtle = null;
            savingRhinoSystem.setQuit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal")
        {
            //to show the green circle ui
            other.gameObject.GetComponent<Rhino>().nearPlayer(true);
            if (!canCatch.Contains(other.gameObject)) { canCatch.Add(other.gameObject); }
        }

        if (other.tag == "attack")
        {
            //the player get hurt by the rhino horns
            savingRhinoSystem.getHurt(10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "animal")
        {
            //to not show the green circle ui
            other.gameObject.GetComponent<Rhino>().nearPlayer(false);
            canCatch.Remove(other.gameObject);
        }
    }

    //find the catching Rhino by the cloest Rhino
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

        //set the Rhino is catching
        closestTurtle.GetComponent<Rhino>().catching(true);

        return closestTurtle;
    }

    public void playerStopCatching()
    {
        if(closestTurtle != null)
        {
            closestTurtle.GetComponent<Rhino>().catching(false);
            closestTurtle = null;
        }
    }

    //when player catched the Rhino
    public void destroyedTurtle(GameObject Rhino)
    {
        canCatch.Remove(Rhino);
    }
}
