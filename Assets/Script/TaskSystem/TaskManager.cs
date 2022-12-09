using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    TaskList taskList;
    Task task;
    public int taskOrder;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject startBtn;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        taskList = FindObjectOfType<TaskList>();
        task = taskList.taskList[taskOrder-1];
        animator = gameObject.GetComponent<Animator>();
    }

    public void StartDialogue()
    {
        //close dialogue if it open
        DialogueManager dialogueManager;
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager)
        {
            dialogueManager.EndDialogue();
        }

        animator.SetBool("isOpen", true);
        nameText.text = task.name;
        StartCoroutine(TypeSentence(task.message));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void Accept()
    {
        Player player = FindObjectOfType<Player>();
        player.SetTastState(taskOrder);
        EndDialogue();
        startBtn.SetActive(false);
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        startBtn.SetActive(true);
    }
}
