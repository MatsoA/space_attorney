using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseButtonScript : MonoBehaviour
{
    public string nextId;
    public bool endFlag;

    public void onSelect() {
        Debug.Log("clicked");
        if (endFlag)
        {
            DialogueBoxController.instance.EndDialogue(nextId);
        } else {
            DialogueBoxController.instance.ShowDialogue(nextId);
        }
    }
}
