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

    [SerializeField] private LightOut contatore; 

    public override void Drop()
    {
       Destroy(gameObject);
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
        return "PER AFFERRARE LA TORCIA";
    }
}
