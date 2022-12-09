using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    private Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject startBtn;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void StartDialogue()
    {
        //close dialogue if it open
        TaskManager taskManager;
        taskManager = FindObjectOfType<TaskManager>();
        if (taskManager)
        {
            taskManager.EndDialogue();
        }

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        startBtn.SetActive(true);
    }
}
