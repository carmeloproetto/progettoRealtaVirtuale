using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevettaInteractable : Interactable
{
    private Animator _animator;
    private bool _isUp; 
    public GameObject uiInteraction;

    public override void Interact(GameObject caller)
    {
        if (_isUp)
        {
            switchOff();
            FindObjectOfType<AudioManager>().Play("Levetta");
        }
        else
        {
            switchOn();
            FindObjectOfType<AudioManager>().Play("Levetta");
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

    public override string GetDescription()
    {
        uiInteraction.SetActive(true);
        return "PER SOLLEVARE O ABBASSARE LA LEVETTA";
    }
}
