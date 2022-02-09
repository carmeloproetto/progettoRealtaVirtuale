using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermostatoManager : MonoBehaviour
{
    private int temperatura;
    private System.DateTime orario;
    private const int TEMP_MAX = 30;
    private const int TEMP_MIN = 15;

    private TMPro.TextMeshProUGUI _orarioMesh; 



    private bool temperatura_corretta = false; 

    public void aumenta()
    {
        if( temperatura < 35)
        {
            temperatura++;
        }

        temperatura_corretta = tempInRange();
    }

    public void diminuisci()
    {
        if( temperatura > TEMP_MIN)
        {
            temperatura--;
        }

        temperatura_corretta = tempInRange(); 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        temperatura = TEMP_MIN;
        orario = System.DateTime.Now;
        _orarioMesh = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        _orarioMesh.text = orario.Hour.ToString() + ":" + orario.Minute.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
        orario = System.DateTime.Now;

        // Display Orario
        _orarioMesh.text = string.Format("{0:00}:{1:00}:{2:00}", orario.Hour, orario.Minute, orario.Second);

        // Display Temperatura

        if ( temperatura_corretta) // temperatura ottimale 
        {

        }
        else // temperatura troppo bassa o troppo alta
        {

        }
    }

    private bool tempInRange()
    {
        return temperatura > 23 && temperatura < 28; 
    }
}
