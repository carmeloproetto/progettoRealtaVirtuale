using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAscent : Interactable
{
    private SalitaAscensore lift_script;
    private PorteAscensoreInteractable close_doors_script;
    public GameObject lift;
    public GameObject doors;

    private VerificaCodice script_verificaCodice;
    public GameObject verificaCodice;

    public override void Interact(GameObject caller)
    {
        if(lift_script.chiamaAssistenza == false){
            if(close_doors_script.firstClose == true){
                FindObjectOfType<AudioManager>().Play("BottoneAscensore");
                FindObjectOfType<AudioManager>().Play("PortaAscensore");
                FindObjectOfType<AudioManager>().Play("SalitaAscensore");
                close_doors_script.open = !close_doors_script.open;
                close_doors_script.firstClose = false;
            }
            lift_script.up = !lift_script.up;
        }
        else{
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            Debug.Log("premuto il tasto 7");  
            script_verificaCodice.codice.Add(7);
        }


    }

    public void Start()
    {
        lift_script = lift.GetComponent<SalitaAscensore>();
        close_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
        script_verificaCodice = verificaCodice.GetComponent<VerificaCodice>();
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(lift_script.up);
    }
}