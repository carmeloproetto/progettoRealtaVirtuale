using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaCodice : Interactable
{
   private ChiamaAssistenzaAscensore script_assistenza;
   public GameObject assistenza;

    public List<int> codice;
    public bool codiceErrato;

    public override void Interact(GameObject caller)
    {
        if(script_assistenza.insert_combo_to_unlock == true){
            FindObjectOfType<AudioManager>().Play("PortaAscensore");  
       
            if(codice.Count == 3)
                if(codice[0] == 7 && codice[1] == 1 && codice[2] == 3)
                    Debug.Log("codice corretto!");
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
    }

    // Update is called once per frame
    void Update()
    {
    }
}