using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseraGrabbable : Grabbable
{
    private Collider _collider;
    private SmoothMovement _movement;
    public FPSInteractionManager interactionManager;
    public PulsanteTermostatoInteractable più;
    public PulsanteTermostatoInteractable meno; 

    public GameObject uiInteraction;
    public GameObject uiInteractionRilascio;
    public GameObject termostato; 

    public override void Drop()
    {
        Destroy(gameObject);
        più.GetComponent<Collider>().enabled = false;
        meno.GetComponent<Collider>().enabled = false;
        uiInteractionRilascio.SetActive(false); 
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _movement.SetMoving();
        Collider termostatoCollider = termostato.GetComponent<Collider>();
        meno.GetComponent<Collider>().enabled = true;
        più.GetComponent<Collider>().enabled = true;
        termostatoCollider.enabled = true;
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
        uiInteraction.SetActive(true);
        return "PER AFFERRARE LA TESSERA";
    }
}
