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
    [SerializeField] GameObject buttonTest; 
    public GameObject Player;

    Conversation currentConversation = null;

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
        currentConversation = conversation;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Player.GetComponent<PlayerController>().inConversation = true;

        ShowDialogue("Start");
    }

    public void ShowDialogue(string Id) {

        //ConvoEntry convoEntry = conversation.convoData[0];

        ConvoEntry convoEntry = currentConversation.convoData.Find(
            delegate(ConvoEntry cv)
            {
                return cv.Id == Id;
            }
        );

        dialogueText.text = convoEntry.Text;
        buttonTest.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = convoEntry.Responses[0].ResponseText;
        buttonTest.GetComponent<ResponseButtonScript>().nextId = convoEntry.Responses[0].NextId;

        buttonTest.GetComponent<ResponseButtonScript>().endFlag = convoEntry.EndFlag;
 
    }

    public void EndDialogue() {
        nameText.text = "";
        dialogueBox.gameObject.SetActive(false);
        currentConversation = null;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.GetComponent<PlayerController>().inConversation = true;

        //ShowDialogue("Start");
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
