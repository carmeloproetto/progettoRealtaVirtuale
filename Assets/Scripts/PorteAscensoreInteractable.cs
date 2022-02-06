using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteAscensoreInteractable : MonoBehaviour
{
    private Animator _animator;
    public bool open;
   
    public bool firstClose;


    private SalitaAscensore lift_script;
    public GameObject lift;

    private LiftAscent salita_script;
    public GameObject salita;
    
    // Start is called before the first frame update
    void Start()
    {
        lift_script = lift.GetComponent<SalitaAscensore>();
        _animator = GetComponent<Animator>();
        open = true;
        firstClose = true;
        salita_script = salita.GetComponent<LiftAscent>();
    }

    private void Update()
    {
        if (open)
            _animator.SetBool("open", false);
        else
            _animator.SetBool("open", true);
    }

    //funzione che scatta quando le porte finisicono di aprirsi
    public void SalitaAscensore(){
        //se è stato premuto il pulsante 7 allora dopo la chiusra
        //delle porte, l'ascensore iniziera' a salire
        if(salita_script.chiamataSalita == true){
            lift_script.up = !lift_script.up;
            salita_script.chiamataSalita = false;
        }
    }

}

