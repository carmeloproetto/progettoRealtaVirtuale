using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = this.GetComponentInChildren<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_light.enabled)
            {
                _light.enabled = false;
            }
            else
            {
                _light.enabled = true; 
            }
        }
    }
}
