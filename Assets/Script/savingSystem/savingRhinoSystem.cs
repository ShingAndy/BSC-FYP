using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class savingRhinoSystem : MonoBehaviour
{
    public Button catchBtn;
    public Slider catchProgress;
    public TMP_Text numberText;
    public int aimNumber;
    private int number;
    private bool quit = false;
    private triggerRhino triggerRhino;
    public GameObject sceneDoor;
    public int catchNeedTime;
    private Player player;

    public Slider hpBar;
    private float hp = 100;
    private bool isDead = false;

    public DialogueManager levelMsg;
    private bool isShowMsg = false;

    // Start is called before the first frame update
    void Start()
    {
        numberText.text = number + "/" + aimNumber;
        triggerRhino = FindObjectOfType<triggerRhino>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //show level msg
        if(number == 0 && !isShowMsg && levelMsg)
        {
            isShowMsg = true;
            levelMsg.StartDialogue();
        }

        //finished the task
        if (number >= aimNumber && !sceneDoor.activeInHierarchy)
        {
            player.SetTastState(4);
            sceneDoor.SetActive(true);
        }

        if (!catchBtn.enabled)
        {
            setQuit();
        }
    }

    public IEnumerator Catching()
    {
        if (number >= aimNumber || isDead)
            yield break;

        //set the catch target
        GameObject savingRhino = triggerRhino.getCloestTurtle();

        //reset valuable
        quit = false;
        catchProgress.gameObject.SetActive(true);
        catchProgress.value = 0;

        float counter = 0;

        while (counter < catchNeedTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            catchProgress.value = counter/ catchNeedTime;
            player.LookAt(savingRhino);
            player.Catching(true);
            if (quit)
            {
                //Quit function
                catchProgress.gameObject.SetActive(false);
                player.Catching(false);
                yield break;
            }
            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }

        //success catching
        triggerRhino.destroyedTurtle(savingRhino);
        savingRhino.GetComponent<Rhino>().DestroyObject();
        number++;
        numberText.text = number + "/" + aimNumber;
        catchProgress.gameObject.SetActive(false);
        setQuit();
    }

    public void setQuit()
    {
        quit = true;
        player.Catching(false);
    }

    public void getHurt(int damage)
    {
        //player already died
        if (isDead)
            return;

        //if hp is 0, player died and reload the scense
        if (hp <= 0)
        {
            isDead = true;
            player.Die();
            Invoke("gameOver", 2f);
            return;
        }

        player.Hurt();
        hp -= damage;
        hpBar.value = hp/100;
    }

    private void gameOver()
    {
        loadingScene loadingScene = FindObjectOfType<loadingScene>();
        loadingScene.LoadScene(1);
    }
}
