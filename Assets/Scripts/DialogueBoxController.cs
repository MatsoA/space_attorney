using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class DialogueBoxController : MonoBehaviour
{
    
    public static DialogueBoxController instance;

    [SerializeField] TMP_Text dialogueText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] GameObject dialogueBox;

    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;
    bool inConversation;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    public void StartDialogue(Conversation conversation, string name) {
        nameText.text = name;
        dialogueBox.gameObject.SetActive(true);
        ShowDialogue(conversation);
    }

    void ShowDialogue(Conversation conversation) {
        inConversation = true;

        ConvoEntry convoEntry = conversation.convoData[0];

        while (inConversation) 
        {
            DialoguePoint dialoguePoint = convoEntry.dialoguePoint;

            dialogueText.text = dialoguePoint.Text;
        }
    }
    

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
