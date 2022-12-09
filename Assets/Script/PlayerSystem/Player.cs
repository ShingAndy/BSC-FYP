using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int hp;
    private int money;
    private float tastState;
    private float countTime;
    private Vector3 oldPosition;
    private int sceneLevel;

    public Animator savingUI;

    void Start()
    {
        //PlayerPrefs can't save boolean
        int isSaved = PlayerPrefs.GetInt("isSaved");

        if (isSaved == 1)
        {
            //set the data using the saved date
            hp = PlayerPrefs.GetInt("hp");
            money = PlayerPrefs.GetInt("money");
            tastState = PlayerPrefs.GetFloat("tastState");
            sceneLevel = PlayerPrefs.GetInt("sceneLevel");

            if(sceneLevel!= SceneManager.GetActiveScene().buildIndex)
            {
                FindObjectOfType<loadingScene>().LoadScene(sceneLevel);
            }
        }
        else
        {
            hp = 100;
            money = 0;
            tastState = 0;
        }
        SaveGame();
        countTime = 20;
        oldPosition = transform.position;
    }

    void Update()
    {
        //if player don't move for long time, game will auto save
        if (countTime > 0 && Vector3.Distance(oldPosition, transform.position)<1)
        {
            countTime -= Time.deltaTime;
        }
        else if (countTime > 0)
        {
            countTime = 20;
            oldPosition = transform.position;
        }
        else
        {
            SaveGame();
            countTime = 20;
        }
    }

    public void GetHurt(int hurt)
    {
        hp -= hurt;
    }

    public void GetMoney(int money)
    {
        money += money;
    }

    public void LostMoney(int money)
    {
        money -= money;
    }

    public void AddTastState(float add)
    {
        tastState += add;
    }

    public void SaveGame()
    {
        savingUI.Play("saving");
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetFloat("tastState", tastState);
        PlayerPrefs.SetInt("sceneLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isSaved", 1);
    }
}
