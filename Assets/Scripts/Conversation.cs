using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using UnityEngine;

[System.Serializable]
public struct DialoguePoint 
{
    public string Text;
    public string[] Responses;
    public bool EndFlag;
}

[System.Serializable]
public struct DictionaryEntry
{
    string Id;
    DialoguePoint dialogue_point; 
}

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
    public List<DictionaryEntry> convoData;

}
