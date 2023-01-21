using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTurtle : MonoBehaviour
{
    public GameObject catchBtn;
    public GameObject catchBar;
    private GameObject[] canCatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canCatch = GameObject.FindGameObjectsWithTag("canCatch");
        if (canCatch.Length > 0)
        {
            catchBtn.SetActive(true);
        }
        else
        {
            catchBtn.SetActive(false);
            catchBar.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal")
        {
            other.gameObject.GetComponent<turtle>().nearPlayer(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "animal")
        {
            other.gameObject.GetComponent<turtle>().nearPlayer(false);
        }
    }
}
