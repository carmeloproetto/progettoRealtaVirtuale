using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiamaAssistenzaAscensore : Interactable
{
    private SalitaAscensore lift_script;
    public GameObject lift;

    public bool insert_combo_to_unlock;

    bool firstCall;

    public bool unlockBtn;
    public bool btn;

    public GameObject uiInteraction;

    public override void Interact(GameObject caller)
    {
        if (FindObjectOfType<AudioManager>().inPlay == false)
        {
            if (firstCall == true && lift_script.chiamaAssistenza == true)
            {
                FindObjectOfType<AudioManager>().Play("AllarmeAscensore");
                FindObjectOfType<AudioMedicoManager>().Play("AscensoreBloccato");
                firstCall = false;
                insert_combo_to_unlock = true;
                unlockBtn = true;
            }
        }
    }

    public void Start()
    {
       lift_script = lift.GetComponent<SalitaAscensore>();
       firstCall = true;
       insert_combo_to_unlock = false;
       unlockBtn = false;
       btn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<AudioMedicoManager>().inPlay == false && unlockBtn == true)
            btn = true;
    }

    public override string GetDescription()
    {
        if(lift_script.chiamaAssistenza == true && unlockBtn == false){
            uiInteraction.SetActive(true);
            return "PER CHIAMARE ASSISTENZA";
        }else{
            uiInteraction.SetActive(false);
            return null;
        }
    }
}