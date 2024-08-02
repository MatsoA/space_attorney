using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class DialogueBoxController : MonoBehaviour
{
    public Conversation conversation;

    void Start() {
        Debug.Log("eee");

        conversation.printData();
        
    }

    void RunDialogue () {
        
    }







    // public static DialogueBoxController instance;

    // [SerializeField] TMP_Text dialogueText;
    // [SerializeField] TMP_Text nameText;
    // [SerializeField] CanvasGroup dialogueBox;

    // public static event Action OnDialogueStarted;
    // public static event Action OnDialogueEnded;
    // bool skipLineTriggered;

    // private void Awake()
    // {
    //     if (instance == null) {
    //         instance = this;
    //     }
    //     else {
    //         Destroy(this);
    //     }
    // }

    // public void StartDialogue(string[] dialogue, int startPosition, string name)
    // {
    //     nameText.text = name + "...";
    //     dialogueBox.gameObject.SetActive(true);
    //     StopAllCoroutines();
    //     StartCoroutine(RunDialogue(dialogue, startPosition));
    // }

    // IEnumerator RunDialogue(string[] dialogue, int startPosition)
    // {
    //     skipLineTriggered = false;
    //     OnDialogueStarted?.Invoke();

    //     while(dialogue[i].endFlag != "true")
    //     {
    //         dialogueText.text = dialogue[i].text;
    //         while (skipLineTriggered == false)
    //         {
    //             // Wait for the current line to be skipped
    //             yield return null;
    //         }
    //         skipLineTriggered = false;
    //     }

    //     OnDialogueEnded?.Invoke();
    //     dialogueBox.gameObject.SetActive(false);
    // }

    // public void SkipLine()
    // {
    //     skipLineTriggered = true;
    // }
}
