using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseButtonScript : MonoBehaviour
{
    public string nextId;
    public bool endFlag;

    public void onSelect() {
        if (endFlag)
        {
            DialogueBoxController.instance.EndDialogue();
        } else {
            DialogueBoxController.instance.ShowDialogue(nextId);
        }
    }
}
