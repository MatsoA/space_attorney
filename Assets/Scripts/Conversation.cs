using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using UnityEngine;
using System;

[Serializable]
public struct DialoguePoint 
{
    public string Text;
    public string[] Responses;
    public bool EndFlag;
}

[Serializable]
public struct ConvoEntry
{
    public string Id;
    public DialoguePoint dialoguePoint;
}

[CreateAssetMenu]
public class Conversation : ScriptableObject
{

    public char testField;
    [SerializeField] public List<ConvoEntry> convoData;

    public void printData() {
        foreach (var entry in this.convoData)
        {
            Debug.Log(entry.dialoguePoint.Text);
            Debug.Log(entry.dialoguePoint.Responses);
            Debug.Log(entry.dialoguePoint.EndFlag);
        }
    }

}
