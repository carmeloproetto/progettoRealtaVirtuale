using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOut : MonoBehaviour
{
    public Light light;

    private float timer = 0;
    public bool on = false;
    private const float timeInterval = 30;
    private LevettaInteractable[] levette;
    private SchermoContManager schermo; 

    // Start is called before the first frame update
    void Start()
    {
        levette = GetComponentsInChildren<LevettaInteractable>();
        schermo = GetComponentInChildren<SchermoContManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if( on ) // timer on 
        {
            timer += Time.deltaTime;
            Debug.Log(timer); 
            if( timer >= timeInterval)
            {
                light.enabled = false; // light off
                on = false;
                timer = 0; 
                foreach (LevettaInteractable l in levette)
                {
                    l.switchOff(); // abbasso le levette
                    schermo.Off(); // schermo in warning
                    Collider collider = l.gameObject.GetComponent<Collider>(); // abilito l'interazione con le levette
                    collider.enabled = true; 
                }
                Debug.Log("Timer out -> Light switched off"); 
            }
        }
    }

    public void timerOn()
    {
        on = true; 
    }
}
