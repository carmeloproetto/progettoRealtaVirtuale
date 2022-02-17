using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaCodice : Interactable
{
   private ChiamaAssistenzaAscensore script_assistenza;
   public GameObject assistenza;
   private SchermoAscensore schermo; 

    //script per medico
    public GameObject medico;
    private PrimoDialogoScript script_medico;
    public Transform posMedSecondoPiano;

   public List<int> codice;
   public bool codiceErrato;

   //script che fa partire l'animazione dell'ascensore una volta sbloccato
   private SalitaAscensore script_unlock;
   public GameObject unlock;

    public override void Interact(GameObject caller)
    {

        if(script_assistenza.insert_combo_to_unlock == true && FindObjectOfType<AudioMedicoManager>().inPlay == false)
        {
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");

            if (codice.Count == 3)
                if (codice[0] == 7 && codice[1] == 1 && codice[2] == 3)
                {
                    //sblocco il dialogo con il medico e lo teletrasporto al secodno piano
                    Debug.Log("Posizione medico"+ medico.transform.position);
                    Debug.Log("Posizione secondo piano"+ posMedSecondoPiano.transform.position);
                    script_medico.isTalking = false;
                    script_medico.numberOfQuestion = 8;
                    medico.transform.position = posMedSecondoPiano.transform.position;
                    Debug.Log("Posizione medico dopo asseganzione"+ medico.transform.position);

                    
                    
                    FindObjectOfType<AudioManager>().Play("SalitaAscensore2");
                    Debug.Log("codice corretto!");
                    //parte l'animazione di salita dell'ascensore
                    
                    script_unlock.unlock = true;
                    schermo.Salita();
                   
                }
                else
                {
                    Debug.Log("codice errato 2");
                    FindObjectOfType<AudioManager>().Play("WrongCode");
                }


            else { 
                Debug.Log("codice errato 3");
                FindObjectOfType<AudioManager>().Play("WrongCode");
            }
                
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
        schermo = GetComponentInParent<SchermoAscensore>(); 
        script_medico = medico.GetComponent<PrimoDialogoScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

}