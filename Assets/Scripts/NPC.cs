using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IInteractable
{
    public GameObject HelperHand;
    [SerializeField] public bool isInteractable = true;

    public string npcName;
    public Conversation conversation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HelperEnter () {
        if (isInteractable) {
           HelperHand.SetActive(true);
        }
    }

    public void HelperExit () {
        if (isInteractable) {
            HelperHand.SetActive(false);
        }
    }
    
    public void Interact () 
    {
        if (isInteractable) {
            HelperHand.SetActive(false);
            DialogueBoxController.instance.StartDialogue(conversation, npcName);
        }
    }

    public void EndInteract () {
        Debug.Log("Closed");
    }
}
