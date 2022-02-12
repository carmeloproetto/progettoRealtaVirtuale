using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicoAnimationManager : MonoBehaviour
{
    private Animator _animator;

    public GameObject medico;
    private PrimoDialogoScript script_medico;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        script_medico = medico.GetComponent<PrimoDialogoScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<AudioMedicoManager>().isPlaying()) // il medico sta parlando 
        {
            _animator.SetBool("Talking", true); 
        }
        else
        {
            _animator.SetBool("Talking", false); 
        }
        
        if(script_medico.walking == true){
            _animator.SetBool("Walking", true);
        }
        else{
            _animator.SetBool("Walking", false);
        }
    }
}
