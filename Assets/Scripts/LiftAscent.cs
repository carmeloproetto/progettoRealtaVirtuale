using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAscent : Interactable
{
    private SalitaAscensore lift_script;
    private PorteAscensoreInteractable close_doors_script;
    public GameObject lift;
    public GameObject doors;

    private ChiamaAssistenzaAscensore script_assistenza;
    public GameObject assistenza;


    private VerificaCodice script_verificaCodice;
    public GameObject verificaCodice;
 
    //serve per distringuere l'apertura delle porte da fuori l'ascensore
    public bool chiamataSalita;

    public bool blockOtherButton;

    private SchermoAscensore schermo; 

    public TMPro.TextMeshProUGUI textOfDisplay;

    bool aux;

    public override void Interact(GameObject caller)
    {
        if(lift_script.chiamaAssistenza == false && aux != true){
            FindObjectOfType<AudioMedicoManager>().StopPlaying("PianoSbagliato");
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            FindObjectOfType<AudioManager>().Play("PortaAscensore");
            FindObjectOfType<AudioManager>().Play("SalitaAscensore");

            schermo.Salita();
            aux = true;
            //se il pulsante 7 e' il primo ad essere cliccato chiudo le porte
            if (close_doors_script.firstClose == true){
                close_doors_script.open = !close_doors_script.open;
                close_doors_script.firstClose = false;
                 //booleano necessario in PorteAscensoreInteractable.cs 
                //serve per far scattare la salita dell'ascensore dopo
                //la chiusura delle porte se e solo se e' stato premuto
                //il pulsante 7, ovvero quello del piano corretto
                chiamataSalita = true;
            }
            else{
                //le porte sono gia' chiuse
                //devo solo salire
                lift_script.up = !lift_script.up;
            }
           
            blockOtherButton = true;
        }
        else if(script_assistenza.btn == true && script_verificaCodice.correctCode != true){
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            Debug.Log("premuto il tasto 7");  
            script_verificaCodice.codice.Add(7);
            if(script_verificaCodice.codice.Count == 1)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString();
                else if(script_verificaCodice.codice.Count == 2)
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString();
                else
                    textOfDisplay.text = script_verificaCodice.codice[0].ToString() + script_verificaCodice.codice[1].ToString() + script_verificaCodice.codice[2].ToString();
     
        }


    }

    public void Start()
    {
        lift_script = lift.GetComponent<SalitaAscensore>();
        close_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
        script_verificaCodice = verificaCodice.GetComponent<VerificaCodice>();
        chiamataSalita = false;
        schermo = GetComponentInParent<SchermoAscensore>(); 
        blockOtherButton = false;
        script_assistenza = assistenza.GetComponent<ChiamaAssistenzaAscensore>();
   }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(lift_script.up);
    }

    public override string GetDescription()
    {
        return "PER SCEGLIERE IL PIANO";
    }
}