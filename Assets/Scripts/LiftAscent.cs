using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAscent : Interactable
{
    private SalitaAscensore lift_script;
    private PorteAscensoreInteractable close_doors_script;
    public GameObject ant;
    public GameObject doors;
    public override void Interact(GameObject caller)
    {
        Debug.Log("ant" + ant);
        lift_script.up = !lift_script.up;
        close_doors_script.open = !close_doors_script.open;
        Debug.Log("lift_script " + lift_script);
    }

    public void Start()
    {
        lift_script = ant.GetComponent<SalitaAscensore>();
        close_doors_script = doors.GetComponent<PorteAscensoreInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lift_script.up);
    }
}