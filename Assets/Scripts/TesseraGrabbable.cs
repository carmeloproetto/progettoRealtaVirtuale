using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseraGrabbable : Grabbable
{
    private Collider _collider;
    private SmoothMovement _movement;
    public FPSInteractionManager interactionManager; 

    public override void Drop()
    {
        Destroy(gameObject);
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _movement.SetMoving();
        interactionManager.setDuringTask(true);

        FindObjectOfType<AudioManager>().Play("Grab");
    }

    protected override void Start()
    {
        _collider = GetComponent<Collider>();
        _movement = GetComponent<SmoothMovement>();
    }

    public override string GetDescription()
    {
        return "PER AFFERRARE LA TESSERA";
    }
}
