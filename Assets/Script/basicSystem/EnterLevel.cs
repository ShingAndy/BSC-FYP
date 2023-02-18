using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public int level;
    public int requiredTaskState;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
            return;
        Player player = FindObjectOfType<Player>();
        if(player.GetTastState() >= requiredTaskState)
        {
            loadingScene loadingScene = FindObjectOfType<loadingScene>();
            loadingScene.LoadScene(level);
        }
    }

}
