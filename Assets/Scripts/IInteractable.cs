using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{

    void HelperEnter();

    void HelperExit();

    void Interact();
    
    void EndInteract();
}
