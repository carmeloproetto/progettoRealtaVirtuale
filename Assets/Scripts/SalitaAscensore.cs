using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalitaAscensore : MonoBehaviour
{
    private Animator _animator;
    public bool up;
    public bool chiamaAssistenza;
  
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        up = true;
        chiamaAssistenza = false;
    }

    private void Update()
    {
        if (up){
            _animator.SetBool("up", false);
            //insert_combo_to_unlock = true;
        }
        else{
            _animator.SetBool("up", true);
            chiamaAssistenza = true;
        }
    }
}

