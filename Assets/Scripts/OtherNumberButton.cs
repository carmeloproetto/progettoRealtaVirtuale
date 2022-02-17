using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherNumberButton : Interactable
{
    private SalitaAscensore lift_script;
    public GameObject lift;

    private PorteAscensoreInteractable close_doors_script;
    public GameObject doors;

    private VerificaCodice script_verificaCodice;
    public GameObject verificaCodice;

     public override void Interact(GameObject caller)
    {
         Debug.Log("stiamo premendo");
        
        if(close_doors_script.firstClose == true){
            close_doors_script.open = !close_doors_script.open;
            close_doors_script.firstClose = false;
        }
        if(lift_script.chiamaAssistenza == false){
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            FindObjectOfType<AudioMedicoManager>().Play("PianoSbagliato");
        }
        else{
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            string objectName = gameObject.name;
            Debug.Log(objectName);  
            if(objectName == "tasto8")
                script_verificaCodice.codice.Add(8); 
            else if(objectName == "tasto6")
                script_verificaCodice.codice.Add(6);
            else if(objectName == "tasto5")
                script_verificaCodice.codice.Add(5);
            else if(objectName == "tasto4")
                script_verificaCodice.codice.Add(4);
            else if(objectName == "tasto3")
                script_verificaCodice.codice.Add(3);
            else if(objectName == "tasto2")
                script_verificaCodice.codice.Add(2);
            else if(objectName == "tasto1")
                script_verificaCodice.codice.Add(1);
        }
        

       
    }


    // Start is called before the first frame update
    void Start()
    {
        lift_script = lift.GetComponent<SalitaAscensore>();
        close_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
        script_verificaCodice = verificaCodice.GetComponent<VerificaCodice>();
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(lift_script.insert_combo_to_unlock);
    }
}
