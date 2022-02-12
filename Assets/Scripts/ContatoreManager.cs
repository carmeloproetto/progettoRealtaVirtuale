using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContatoreManager : MonoBehaviour
{
    private LevettaInteractable[] levette;
    private SchermoContManager schermoManager; 
    public Light light; 

    // Start is called before the first frame update
    void Start()
    {
        levette = GetComponentsInChildren<LevettaInteractable>();
        schermoManager = GetComponentInChildren<SchermoContManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if( !levette[0].isUp() && levette[1].isUp() && levette[2].isUp() && !levette[3].isUp())
        {
            light.enabled = true;
            schermoManager.On();

            
        }
    }
}
