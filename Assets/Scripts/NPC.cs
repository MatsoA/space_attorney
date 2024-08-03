using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] public bool isInteractable = true;

    public string npcName;
    public Conversation conversation;


    // Start is called before the first frame update
    void Start() { }

    public void HelperEnter () { }

    public void HelperExit () { }
    
    public void Interact () {
        if (isInteractable) {
            DialogueBoxController.instance.StartDialogue(conversation, npcName);
        }
    }

    public void EndInteract () { }
}
