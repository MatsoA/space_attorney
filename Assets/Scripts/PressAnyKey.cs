using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public CameraController cam;
    public PlayerController play;

    void Update() {
        if (Input.anyKey) {
            cam.enabled = true;
            play.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
