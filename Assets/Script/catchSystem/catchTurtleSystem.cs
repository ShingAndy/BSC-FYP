using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class catchTurtleSystem : MonoBehaviour
{
    public Button catchBtn;
    public Slider catchProgress;
    public TMP_Text numberText;
    public int aimNumber;
    private int number;
    private bool quit = false;
    private triggerTurtle triggerTurtle;
    public GameObject sceneDoor;
    public int catchNeedTime;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        numberText.text = number + "/" + aimNumber;
        triggerTurtle = FindObjectOfType<triggerTurtle>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(number >= aimNumber && !sceneDoor.activeInHierarchy)
        {
            player.SetTastState(2);
            sceneDoor.SetActive(true);
        }

        if (!catchBtn.enabled)
        {
            setQuit();
        }
    }

    public IEnumerator Catching()
    {
        if (number >= aimNumber)
            yield break;

        //set the catch target
        GameObject catchingTurtle = triggerTurtle.getCloestTurtle();

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
            player.LookAt(catchingTurtle);
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
        triggerTurtle.destroyedTurtle(catchingTurtle);
        catchingTurtle.GetComponent<turtle>().DestroyObject();
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
}
