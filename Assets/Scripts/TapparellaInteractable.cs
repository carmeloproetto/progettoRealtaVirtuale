using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapparellaInteractable : Interactable
{
    private Animator _animator;

    public override string GetDescription()
    {
        return "PER APRIRE E CHIUDERE LA TAPPARELLA";
    }

    public override void Interact(GameObject caller)
    {
        bool up = _animator.GetBool("Up");
        if (up)
        {
            _animator.SetBool("Up", false);
        }
        else _animator.SetBool("Up", true);

        FindObjectOfType<AudioManager>().Play("Tapparella");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
