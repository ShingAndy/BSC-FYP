using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userSetting : MonoBehaviour {

    GameObject[] soundObject;
    private int muted;
    public GameObject mutedBtn;
    public GameObject unMutedBtn;

    void Start()
    {
        muted = PlayerPrefs.GetInt("muted", 0);
        //find all gameobject with audio source
        soundObject = GameObject.FindGameObjectsWithTag("Sound");
        if (muted == 1)
        {
            MuteSound();
            unMutedBtn.SetActive(true);
        }
        else
        {
            mutedBtn.SetActive(true);
        }
    }

    void Update()
    {

    }

    public void MuteSound()
    {
        //mute or unmute all audio source
        for(int i = 0; i< soundObject.Length; i++)
        {
            soundObject[i].GetComponent<AudioSource>().mute = true;
        }
        muted = 1;
        PlayerPrefs.SetInt("muted", 1);
    }

    public void UnMuteSound()
    {
        //mute or unmute all audio source
        for (int i = 0; i < soundObject.Length; i++)
        {
            soundObject[i].GetComponent<AudioSource>().mute = false;
        }
        muted = 0;
        PlayerPrefs.SetInt("muted", 0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
