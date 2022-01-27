using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalitaAscensore : Interactable
{
    private Animator _animator;
    public bool up;
    public override void Interact(GameObject caller)
    {
       // up = _animator.GetBool("up");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        up = true;
    }

    private void Update()
    {
        if (up)
            _animator.SetBool("up", false);
        else
            _animator.SetBool("up", true);
    }
}

