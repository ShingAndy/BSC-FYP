using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int hp;
    private int money;
    private int tastState;
    private float countTime;
    private Vector3 oldPosition;
    private int sceneLevel;

    public Animator savingUI;

    private Task acceptedTask;

    void Start()
    {
        //PlayerPrefs can't save boolean
        int isSaved = PlayerPrefs.GetInt("isSaved");

        if (isSaved == 1)
        {
            //set the data using the saved date
            hp = PlayerPrefs.GetInt("hp");
            money = PlayerPrefs.GetInt("money");
            tastState = PlayerPrefs.GetInt("tastState");
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
        SaveGame();
    }

    public void GetMoney(int money)
    {
        money += money;
        SaveGame();
    }

    public void LostMoney(int money)
    {
        money -= money;
        SaveGame();
    }

    public void SetTastState(int add)
    {
        tastState = add;
        SaveGame();
    }

    public int GetTastState()
    {
        return tastState;
    }

    public void SaveGame()
    {
        savingUI.Play("saving");
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("tastState", tastState);
        PlayerPrefs.SetInt("sceneLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isSaved", 1);
    }

    public void resetAll()
    {
        hp = 100;
        money = 0;
        tastState = 0;
        sceneLevel = 1;
        SaveGame();
    }
}
