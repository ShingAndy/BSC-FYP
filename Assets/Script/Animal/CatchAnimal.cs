using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchAnimal : MonoBehaviour
{
    public GameObject circleUi;
    protected Image circle;
    protected Animator animator;

    private void Start()
    {
        //get the circle ui
        circle = circleUi.GetComponent<Image>();
        animator = circleUi.GetComponent<Animator>();
    }

    public void nearPlayer(bool yes)
    {
        if (yes)
            circleUi.SetActive(true);
        else
            circleUi.SetActive(false);
    }

    //catching animation
    public void catching(bool yes)
    {
        if (yes)
        {
            animator.SetBool("catching", true);
            circle.color = new Color32(255, 0, 0, 100);
        }
        else
        {
            animator.SetBool("catching", false);
            circle.color = new Color32(32, 255, 0, 100);
        }
    }
}
