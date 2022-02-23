using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : Interactable
{
    private PorteAscensoreInteractable bool_script;
    public GameObject ant;

    public bool locked;
    public GameObject uiInteraction;

    public override void Interact(GameObject caller)
    {
        if(!locked && FindObjectOfType<AudioMedicoManager>().inPlay == false)
        {
         bool_script.open = !bool_script.open;
         FindObjectOfType<AudioManager>().Play("BottoneAscensore");
         FindObjectOfType<AudioManager>().Play("PortaAscensore");
        }
    }

    public void Start()
    {
        bool_script = ant.GetComponent<PorteAscensoreInteractable>();
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string GetDescription()
    {
        if(locked == false){
            uiInteraction.SetActive(true);
            return "PER APRIRE LE PORTE DELL'ASCENSORE";
        }
        else{
            uiInteraction.SetActive(false);
            return null;
        }
    }
}
