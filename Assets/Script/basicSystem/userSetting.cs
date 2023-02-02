using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userSetting : MonoBehaviour {

    GameObject[] soundObject;

    void Start()
    {
        //find all gameobject with audio source
        soundObject = GameObject.FindGameObjectsWithTag("Sound");
    }

    void Update()
    {

    }

    public void MuteSound()
    {
        //mute or unmute all audio source
        for(int i = 0; i< soundObject.Length; i++)
        {
            soundObject[i].GetComponent<AudioSource>().mute = !soundObject[i].GetComponent<AudioSource>().mute;
        }
    }
}
