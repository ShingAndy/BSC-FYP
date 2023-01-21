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
    private bool canCatch;
    public int aimNumber;
    private int number;
    private bool quit = false;

    // Start is called before the first frame update
    void Start()
    {
        numberText.text = number + "/" + aimNumber;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Catching()
    {
        //reset valuable
        quit = false;
        catchProgress.gameObject.SetActive(true);
        catchProgress.value = 0;

        float waitTime = 3;
        float counter = 0;

        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            catchProgress.value = counter/waitTime;
            if (quit)
            {
                //Quit function
                yield break;
            }
            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }

        number++;
        numberText.text = number + "/" + aimNumber;
        catchProgress.gameObject.SetActive(false);
    }

    public void setQuit()
    {
        quit = true;
    }
}
