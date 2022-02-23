using System.Collections;
using UnityEngine;

public class CassettoInteractable : Interactable
{
    private Animator _animator;

    public override string GetDescription()
    {
        return "PER INTERAGIRE CON IL CASSETTO";
    }

    public override void Interact(GameObject caller)
    {
        bool opened = _animator.GetBool("Open");
        if (opened)
        {
            _animator.SetBool("Open", false);

            FindObjectOfType<AudioManager>().Play("Cassetto");
        }
        else _animator.SetBool("Open", true);

        FindObjectOfType<AudioManager>().Play("Cassetto");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
