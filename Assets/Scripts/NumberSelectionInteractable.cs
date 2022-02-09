using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSelectionInteractable : Interactable
{
    string currentNumber;
    public override void Interact(GameObject caller)
    {
        Debug.Log("premuto");
        currentNumber = gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text;
        Debug.Log("number pressed:" + currentNumber);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
