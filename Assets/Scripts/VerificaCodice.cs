using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaCodice : Interactable
{
   private ChiamaAssistenzaAscensore script_assistenza;
   public GameObject assistenza;

    private PorteAscensoreInteractable close_doors_script;
    public GameObject doors;


    public List<int> codice;
    public bool codiceErrato;

    //script che fa partire l'animazione dell'ascensore una volta sbloccato
    private SalitaAscensore script_unlock;
    public GameObject unlock;

    public override void Interact(GameObject caller)
    {

        if(script_assistenza.insert_combo_to_unlock == true){
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");  
       
            if(codice.Count == 3)
                if(codice[0] == 7 && codice[1] == 1 && codice[2] == 3){
                    FindObjectOfType<AudioManager>().Play("SalitaAscensore");
                    Debug.Log("codice corretto!");
                    script_unlock.unlock = true;
                    close_doors_script.open = !close_doors_script.open;
                }
                else
                    Debug.Log("codice errato 2");
            else
                Debug.Log("codice errato 3");
            codiceErrato = false;      
            codice.Clear();
        }

    }

    public void Start()
    {
        script_assistenza = assistenza.GetComponent<ChiamaAssistenzaAscensore>();
        codice = new List<int>();
        codiceErrato = false;
        script_unlock = unlock.GetComponent<SalitaAscensore>();
        close_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}