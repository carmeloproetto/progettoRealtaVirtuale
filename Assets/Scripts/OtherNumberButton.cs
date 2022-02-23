using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherNumberButton : Interactable
{
    private SalitaAscensore lift_script;
    public GameObject lift;

    private LiftAscent number7_script;
    public GameObject number7;

    private PorteAscensoreInteractable close_doors_script;
    public GameObject doors;

    private VerificaCodice script_verificaCodice;
    public GameObject verificaCodice;

    private ChiamaAssistenzaAscensore script_assistenza;
    public GameObject assistenza;


    public TMPro.TextMeshProUGUI textOfDisplay;

     public override void Interact(GameObject caller)
    {
        if(close_doors_script.firstClose == true){
            close_doors_script.open = !close_doors_script.open;
            close_doors_script.firstClose = false;
        }
        if(lift_script.chiamaAssistenza == false && number7_script.blockOtherButton == false){
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            FindObjectOfType<AudioMedicoManager>().Play("PianoSbagliato");
        }
        else if(lift_script.chiamaAssistenza == true && script_assistenza.btn == true && script_verificaCodice.correctCode != true){
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            string objectName = gameObject.name;
            Debug.Log(objectName);  
            if(objectName == "tasto8"){
                script_verificaCodice.codice.Add(8);
                if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
            }
            else if(objectName == "tasto6"){
                script_verificaCodice.codice.Add(6);
                if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
               }
            else if(objectName == "tasto5"){
                script_verificaCodice.codice.Add(5);
                if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
            }
            else if(objectName == "tasto4"){
                script_verificaCodice.codice.Add(4);
               if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
            }
            else if(objectName == "tasto3"){
                script_verificaCodice.codice.Add(3);
                if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
            }            
            else if(objectName == "tasto2"){
                script_verificaCodice.codice.Add(2);
               if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
     
            }
            else if(objectName == "tasto1"){
                script_verificaCodice.codice.Add(1);
               if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
        
            }
        }
        

       
    }


    // Start is called before the first frame update
    void Start()
    {
        lift_script = lift.GetComponent<SalitaAscensore>();
        close_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
        script_verificaCodice = verificaCodice.GetComponent<VerificaCodice>();
        number7_script = number7.GetComponent<LiftAscent>();
        script_assistenza = assistenza.GetComponent<ChiamaAssistenzaAscensore>();
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(lift_script.insert_combo_to_unlock);
    }

    public override string GetDescription()
    {
        return "PER INTERAGIRE";
    }
}
