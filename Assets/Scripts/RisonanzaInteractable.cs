using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RisonanzaInteractable : Interactable
{

    public GameObject uiInteraction;
    private CambiaCameraRisonanza ScriptCambiaCamera;
    public GameObject cameraRisonanza;

    [SerializeField] private PortaInteractable door;

    public override void Interact(GameObject caller)
    {
        
        ScriptCambiaCamera.camRisonanzaOn = true;
       
        FindObjectOfType<AudioManager>().Play("BipCard");

        if(door.opened)
            {
                door.Close();
                door.doorLocked = true; 
                //FindObjectOfType<AudioMedicoManager>().Play("Freddo");
            }
    }

    public void Start()
    {
        ScriptCambiaCamera = cameraRisonanza.GetComponent<CambiaCameraRisonanza>();
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(bool_script.open);


    }

    public override string GetDescription()
    {
        if(ScriptCambiaCamera.camRisonanzaOn == false){
            uiInteraction.SetActive(true);
            return "PER INIZIARE IL TASK";
        }
        else{
            uiInteraction.SetActive(false);
            return null;
        }
    }
}
