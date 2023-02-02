using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SavingBtnEvent : MonoBehaviour
, IPointerDownHandler
, IPointerUpHandler
, IEventSystemHandler
{
    savingRhinoSystem savingRhinoSystem;
triggerRhino triggerRhino;

private void Start()
{
    // find the catch turtle system script in the parent game object
    savingRhinoSystem = gameObject.GetComponentInParent<savingRhinoSystem>();
    // find the trigger turtle script
    triggerRhino = FindObjectOfType<triggerRhino>();
}

//player start holding the btn
public void OnPointerDown(PointerEventData eventData)
{
    StartCoroutine(savingRhinoSystem.Catching());
}

//player stop holding the btn
public void OnPointerUp(PointerEventData eventData)
{
    savingRhinoSystem.setQuit();
    triggerRhino.playerStopCatching();
}
}