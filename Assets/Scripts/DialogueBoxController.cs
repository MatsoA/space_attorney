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
    [SerializeField] GameObject ButtonPrefab; 
    
    public GameObject Player;
    public GameController gameController;

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

        foreach (Transform child in dialogueBox.transform) {
            if (child.tag == "Button") {
                Destroy(child.gameObject);
            }
        }

        foreach (var response in convoEntry.Responses)
        {
            Debug.Log(response.ResponseText);
            GameObject buttonObject = Instantiate(ButtonPrefab, new Vector3(0,0,0), Quaternion.identity);
            buttonObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = response.ResponseText;
            buttonObject.GetComponent<ResponseButtonScript>().nextId = response.NextId;

            buttonObject.GetComponent<ResponseButtonScript>().endFlag = convoEntry.EndFlag;

            buttonObject.transform.SetParent(dialogueBox.transform, false);    
        }


        // buttonTest.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = convoEntry.Responses[0].ResponseText;
        // buttonTest.GetComponent<ResponseButtonScript>().nextId = convoEntry.Responses[0].NextId;

    }

    public void EndDialogue(string endCode) {
        gameController.changeGameState(endCode);
        nameText.text = "";
        dialogueBox.gameObject.SetActive(false);
        currentConversation = null;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.GetComponent<PlayerController>().inConversation = false;

        //ShowDialogue("Start");
    }

}
