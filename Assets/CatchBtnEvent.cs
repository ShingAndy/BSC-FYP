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

    private void Start()
    {
        // find the catch turtle system script in the parent game object
        catchTurtleSystem = gameObject.GetComponentInParent<catchTurtleSystem>();
    }

    //player start holding the btn
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(catchTurtleSystem.Catching());
    }

    //player stop holding the btn
    public void OnPointerUp(PointerEventData eventData)
    {
        print("stop");
        catchTurtleSystem.setQuit();
        //StopCoroutine(catchTurtleSystem.Catching());
    }
}