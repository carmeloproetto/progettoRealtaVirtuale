using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevettaInteractable : Interactable
{
    private Animator _animator;
    private bool _isUp; 

    public override void Interact(GameObject caller)
    {
        if (_isUp)
        {
            switchOff(); 
        }
        else
        {
            switchOn(); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _isUp = _animator.GetBool("Up");
    }

    public bool isUp()
    {
        return _isUp; 
    }

    public void switchOff()
    {
        _animator.SetBool("Up", false);
        _isUp = false; 
    }

    public void switchOn()
    {
        _animator.SetBool("Up", true);
        _isUp = true;
    }
}
