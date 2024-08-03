using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ResponsePair
{
    public string NextId;
    public string ResponseText;
}

[Serializable]
public struct ConvoEntry
{
    public string Id;
    public string Text;
    [SerializeField] public List<ResponsePair> Responses;
    public bool EndFlag;
}

[CreateAssetMenu]
public class Conversation : ScriptableObject
{

    public char testField;
    [SerializeField] public List<ConvoEntry> convoData;

    public void printData() {
        foreach (var entry in this.convoData)
        {
            Debug.Log(entry.Text);
            foreach(var response in entry.Responses) {
                Debug.Log($"{response.NextId}: {response.ResponseText}");
            };
            Debug.Log(entry.EndFlag);
        }
    }

}
