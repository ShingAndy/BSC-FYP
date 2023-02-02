using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtObject : MonoBehaviour
{
    public GameObject lookAt;
    Camera m_MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        //default looking at the main camera
        if (!lookAt)
            lookAt = m_MainCamera.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - lookAt.transform.position);
    }
}
