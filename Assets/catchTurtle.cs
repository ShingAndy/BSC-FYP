using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchTurtle : MonoBehaviour
{
    public GameObject circleUi;

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
        if (other.tag == "Player")
        {
            circleUi.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            circleUi.SetActive(false);
        }
    }
}
