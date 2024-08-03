using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaryIntensity : MonoBehaviour
{
    Light light;
    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = 0.75f + Mathf.Sin(Time.time)/4f;
    }
}
