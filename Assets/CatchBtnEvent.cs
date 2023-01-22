using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CatchBtnEvent : MonoBehaviour
, IPointerDownHandler
, IPointerUpHandler
, IEventSystemHandler
{
    catchTurtleSystem catchTurtleSystem;
    triggerTurtle triggerTurtle;

    private void Start()
    {
        // find the catch turtle system script in the parent game object
        catchTurtleSystem = gameObject.GetComponentInParent<catchTurtleSystem>();
        // find the trigger turtle script
        triggerTurtle = FindObjectOfType<triggerTurtle>();
    }

    //player start holding the btn
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(catchTurtleSystem.Catching());
    }

    //player stop holding the btn
    public void OnPointerUp(PointerEventData eventData)
    {
        catchTurtleSystem.setQuit();
        triggerTurtle.playerStopCatching();
    }
}