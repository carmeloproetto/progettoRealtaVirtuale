using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : Interactable
{
    private PorteAscensoreInteractable bool_script;
    public GameObject ant;
    public override void Interact(GameObject caller)
    {
        Debug.Log("ant" + ant);
        bool_script.open = !bool_script.open;
        Debug.Log("bool_script " + bool_script);
    }

    public void Start()
    {
        bool_script = ant.GetComponent<PorteAscensoreInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bool_script.open);
    }
}
