using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsanteTermostatoInteractable : Interactable
{
    public bool pulsante_piu = true;

    private TermostatoManager termostato; 

    public override void Interact(GameObject caller)
    {
        if( pulsante_piu)
        {
            termostato.aumenta(); 
        }
        else
        {
            termostato.diminuisci(); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        termostato = gameObject.GetComponentInParent<TermostatoManager>();
    }
}
