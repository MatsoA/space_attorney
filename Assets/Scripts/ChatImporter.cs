using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;
using System;

[ScriptedImporter(1,"chat")]
public class ChatImporter : ScriptedImporter
{
    List<ConvoEntry> readDataIntoConvo(string chatData) 
    {
        Debug.Log(chatData);
        var dialogueDictionary = new List<ConvoEntry>();

        // Clean up the JSON-like string
        chatData = chatData.Replace("\r", "").Replace("\n", "").Trim();
        
        // Remove the outer curly braces
        chatData = chatData.TrimStart('{').TrimEnd('}');

        // Split into individual dialogue points
        var dialogueEntries = chatData.Split("},");

        foreach (var entry in dialogueEntries)
        {
            // Remove leading and trailing braces from each entry
            var trimmedEntry = entry.Trim().TrimStart('{').TrimEnd('}').Trim();

            // // Extract key
            var key = trimmedEntry.Substring(0, trimmedEntry.IndexOf(':')).Trim().Trim('"');
            

            // Extract text, responses, and end flag
            var textStart = trimmedEntry.IndexOf("\"Text\":") + 7;
            var textEnd = trimmedEntry.IndexOf("\"Responses\":") - 1;

            // Debug.Log(trimmedEntry);
            // Debug.Log(textStart);
            // Debug.Log(textEnd);

            var text = trimmedEntry.Substring(textStart, textEnd - textStart).Trim().Trim(',').Trim('"');
            
            var responsesStart = trimmedEntry.IndexOf("\"Responses\":") + 13;
            var responsesEnd = trimmedEntry.IndexOf("\"EndFlag\":") - 1;
            var responsesString = trimmedEntry.Substring(responsesStart, responsesEnd - responsesStart).Trim();
            
            var responses = new List<ResponsePair>();
            if (responsesString != "{}")
            {
                var responsesEntries = responsesString.Trim('[', ']').Split(",");
                foreach (var response in responsesEntries)
                {
                    if (response == "" || response == "    ]") {
                        continue;
                    }  

                    //Debug.Log(response.Trim().Split(':')[1].Trim().Trim('"'));

                    var responseKey = response.Trim().Split(':')[0].Trim().Trim('"');
                    var responseText = response.Trim().Split(':')[1].Trim().Trim('"');

                    responses.Add(new ResponsePair {NextId = responseKey, ResponseText = responseText});
                }
            }
            
            var endFlagStart = trimmedEntry.IndexOf("\"EndFlag\":") + 10;
            var endFlag = trimmedEntry.Substring(endFlagStart).Trim().Trim('"') == "True";
            
            // dialogueDictionary[key] = new DialoguePoint
            // {
            //     Text = text,
            //     Responses = responses.ToArray(),
            //     EndFlag = endFlag
            // };

            dialogueDictionary.Add(new ConvoEntry{
                Id = key,
                dialoguePoint = new DialoguePoint {
                    Text = text,
                    Responses = responses,
                    EndFlag = endFlag
                }
            });


        }

        return dialogueDictionary;
    }

    public override void OnImportAsset(AssetImportContext ctx)
    {
        Conversation newConvo = (Conversation) ScriptableObject.CreateInstance("Conversation");
        
        var chatData = File.ReadAllText(ctx.assetPath);

        newConvo.convoData = readDataIntoConvo(chatData);

        newConvo.testField = chatData[43];

        ctx.AddObjectToAsset("conversation", newConvo);


    }
}


