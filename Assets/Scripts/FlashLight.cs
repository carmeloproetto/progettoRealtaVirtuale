using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (light.enabled)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true; 
            }
        }
    }
}
