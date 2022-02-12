using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapparellaInteractable : Interactable
{
    private Animator _animator;
    public AudioManager audioManager; 

    public override void Interact(GameObject caller)
    {
        bool up = _animator.GetBool("Up");
        if (up)
        {
            _animator.SetBool("Up", false);
        }
        else _animator.SetBool("Up", true);

        audioManager.Play("Tapparella");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
