using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiamaAssistenzaAscensore : Interactable
{
    private SalitaAscensore lift_script;
    public GameObject lift;

    public bool insert_combo_to_unlock;

    bool firstCall;

    public override void Interact(GameObject caller)
    {
        if(firstCall == true && lift_script.chiamaAssistenza == true){
            FindObjectOfType<AudioManager>().Play("AllarmeAscensore");
            FindObjectOfType<AudioManager>().Play("AscensoreBloccato");
            firstCall = false;
            insert_combo_to_unlock = true;
        }
    }

    public void Start()
    {
       lift_script = lift.GetComponent<SalitaAscensore>();
       firstCall = true;
       insert_combo_to_unlock = false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}