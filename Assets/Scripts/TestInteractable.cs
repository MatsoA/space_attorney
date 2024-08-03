using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public TMP_Text helperText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HelperEnter () {
        Debug.Log("Ready");

        helperText.text = "Click E to Interact";
    }

    public void HelperExit () {
        Debug.Log("Ready");

        helperText.text = "";
    }
    
    public void Interact () 
    {
        Debug.Log("Clicked");
    }

    public void EndInteract () {
        Debug.Log("Closed");
    }
}
