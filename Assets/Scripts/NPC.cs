using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IInteractable
{
    public TMP_Text helperText;

    public string name;
    public Conversation conversation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HelperEnter () {
        Debug.Log("Ready");

        helperText.text = $"Click E to speak to {name}";
    }

    public void HelperExit () {
        Debug.Log("Ready");

        helperText.text = "";
    }
    
    public void Interact () 
    {
       DialogueBoxController.instance.StartDialogue(conversation, name);
    }

    public void Uninteract () {
        Debug.Log("Closed");
    }
}
