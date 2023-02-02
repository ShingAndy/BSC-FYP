using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public int level;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
            return;
        loadingScene loadingScene = FindObjectOfType<loadingScene>();
        loadingScene.LoadScene(level);
    }

}
