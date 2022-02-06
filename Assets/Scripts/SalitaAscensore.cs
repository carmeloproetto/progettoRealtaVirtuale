using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalitaAscensore : MonoBehaviour
{
    private Animator _animator;
    public bool up;
    public bool chiamaAssistenza;
    public bool unlock;

    //script per l'apertura delle porte una volta giunti al piano corretto
    private PorteAscensoreInteractable open_doors_script;
    public GameObject doors;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        up = false;
        chiamaAssistenza = false;
        unlock = false; //booleano settato quando viene inserito il codice corretto
        open_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
    }

    private void Update()
    {
         if (up == true){
            _animator.SetBool("up", true);
            chiamaAssistenza = true;
        }
        if(unlock == true)
            _animator.SetBool("unlock", true);
    }

    //scatta quando l'ascensore arriva al piano corretto
    //l'aniamzione 2 della salita dell'ascensore e' terminata
    public void aperturaPorte(){
        Debug.Log("Animazione terminata, apro le porte");
        open_doors_script.open = !open_doors_script.open;
    }
}

