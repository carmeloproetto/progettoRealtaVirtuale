using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContatoreManager : MonoBehaviour
{
    private LevettaInteractable[] levette;
    private SchermoContManager schermoManager; 
    public Light light;
    [SerializeField] private PrimoDialogoScript scriptDialogo; 

    [SerializeField] private PortaInteractable porta; 
    
    public bool completedRoom;

    bool aux;
    // Start is called before the first frame update
    void Start()
    {
        levette = GetComponentsInChildren<LevettaInteractable>();
        schermoManager = GetComponentInChildren<SchermoContManager>();
        completedRoom = false;
        aux = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( !levette[0].isUp() && levette[1].isUp() && levette[2].isUp() && !levette[3].isUp() && aux == true)
        {
            light.enabled = true;
            RenderSettings.ambientLight = new Color32(235, 235, 235, 0);
            schermoManager.On();
            completedRoom = true;
            porta.Unlock();
            scriptDialogo.isTalking = false; 
            aux = false;
        }
    }
}
