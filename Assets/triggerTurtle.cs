using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTurtle : MonoBehaviour
{
    public GameObject catchBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            catchBtn.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "animal")
        {
            catchBtn.SetActive(true);
        }
    }
}
