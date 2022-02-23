using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchGrabbable : Grabbable
{
    public GameObject destination;
    public Camera camera; 
    private Collider _collider;
    private SmoothMovement _movement;
    public FPSInteractionManager interactionManager;
    public GameObject interactionUI;
    public GameObject interactionUiRilascio;

    [SerializeField] private LightOut contatore; 

    public GameObject uiInteraction;

    public override void Drop()
    {
        Destroy(gameObject);
        interactionUiRilascio.SetActive(false); 
    }

    public override void Grab(GameObject grabber)
    {
        interactionManager.setDuringTask(true);
        interactionUI.SetActive(true); 
        _collider.enabled = false;
        _movement.SetMoving();
        contatore.UnlockInteraction();
        FindObjectOfType<AudioManager>().Play("Grab");
    }

    protected override void Start ()
    {
        _collider = GetComponent<Collider>();
        _movement = GetComponent<SmoothMovement>();
    }

    public override string GetDescription()
    {
        uiInteraction.SetActive(true);
        return "PER AFFERRARE LA TORCIA";
    }
}
