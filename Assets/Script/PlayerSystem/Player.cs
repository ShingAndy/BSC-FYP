using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //private int hp;
    //private int money;
    private int taskState;
    private float countTime;
    private Vector3 oldPosition;
    private int sceneLevel;

    public Animator savingUI;
    private NavMeshAgent navMeshAgent;
    private CharacterController characterController;
    private Animator animator;

    public AudioClip[] sounds;
    private AudioSource audioSource;

    void Awake()
    {
        //PlayerPrefs can't save boolean
        int isSaved = PlayerPrefs.GetInt("isSaved");

        if (isSaved == 1)
        {
            //set the data using the saved date
            //hp = PlayerPrefs.GetInt("hp");
            //money = PlayerPrefs.GetInt("money");
            taskState = PlayerPrefs.GetInt("tastState");
            sceneLevel = PlayerPrefs.GetInt("sceneLevel");

            //load the last scene player stay when start game
            if(sceneLevel!= SceneManager.GetActiveScene().buildIndex && SceneManager.GetActiveScene().buildIndex ==1)
            {
                FindObjectOfType<loadingScene>().LoadScene(sceneLevel);
            }
        }
        else
        {
            //hp = 100;
            //money = 0;
            taskState = 0;
            sceneLevel = 1;
            SaveGame();
        }
        countTime = 20;
        oldPosition = transform.position;

        characterController = GetComponent<CharacterController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
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
        //hp -= hurt;
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

    public void SetTastState(int tast)
    {
        taskState = tast;
        SaveGame();
    }

    public int GetTastState()
    {
        return taskState;
    }

    public void SaveGame()
    {
        savingUI.Play("saving");
        //PlayerPrefs.SetInt("hp", hp);
        //PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("tastState", taskState);
        PlayerPrefs.SetInt("sceneLevel", sceneLevel);
        PlayerPrefs.SetInt("isSaved", 1);
    }

    public void resetAll()
    {
        //hp = 100;
        //money = 0;
        taskState = 0;
        sceneLevel = 1;
        SaveGame();
    }

    public void SetNav(Vector3 position)
    {
        characterController.enabled = false;
        navMeshAgent.SetDestination(position);
        animator.SetBool("naving", true);
    }

    public void StopNav()
    {
        characterController.enabled = true;
        if (navMeshAgent.hasPath)
        {
            navMeshAgent.ResetPath();
        }
        animator.SetBool("naving", false);
    }

    public void LookAt(GameObject aim)
    {
        characterController.enabled = false;
        Quaternion rotation = Quaternion.LookRotation(aim.transform.position - transform.position, Vector3.up);
        transform.rotation = rotation;
        //transform.LookAt(aim.transform.position);
    }

    public void Catching(bool yes)
    {
        if(yes)
            animator.SetBool("catching", true);
        else
            animator.SetBool("catching", false);
    }

    public void Hurt()
    {
        animator.SetTrigger("hurt");
        audioSource.clip = sounds[0];
        audioSource.Play();
        Invoke("StopSound", 0.5f);
    }

    public void Die()
    {
        animator.SetTrigger("die");
    }

    private void StopSound()
    {
        audioSource.Stop();
    }
}
