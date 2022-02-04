using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalitaAscensore : MonoBehaviour
{
    private Animator _animator;
    public bool up;
    public bool chiamaAssistenza;
    public bool unlock;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        up = false;
        chiamaAssistenza = false;
        unlock = false; //booleano settato quando viene inserito il codice corretto
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
}

