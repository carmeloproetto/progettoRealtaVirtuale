using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContatoreManager : MonoBehaviour
{
    private LevettaInteractable levette;

    // Start is called before the first frame update
    void Start()
    {
        levette = GetComponentInChildren<LevettaInteractable>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
