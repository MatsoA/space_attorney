using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private string gameState;

    public NPC Boss;
    public NPC Frinkle;
    public NPC Peon2;

    // Start is called before the first frame update
    void Start()
    {
        gameState = "start";
        Boss.isInteractable = false;
        Frinkle.isInteractable = true;
    }

    public void changeGameState(string newState)
    {
        if (newState == "StartAfterFrinkle") {
            Boss.isInteractable = true;
        }
    }
}
