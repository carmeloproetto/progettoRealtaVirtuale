using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermostatoManager : Interactable
{
    private int temperatura;
    private System.DateTime orario;
    private const int TEMP_MAX = 30;
    private const int TEMP_MIN = 15;

    private bool unlocked = false;
    public FPSInteractionManager interactionManager;

    private TMPro.TextMeshProUGUI _orarioMesh;
    private TMPro.TextMeshProUGUI _temperaturaMesh;
    private TMPro.TextMeshProUGUI _dataMesh;

    private Color screenRed = new Color(102.0f, 16.0f, 23.0f, 1.0f);
    private Color screenGreen = new Color(15.0f, 37.0f, 15.0f, 1.0f);
    private Color emissionRed = new Color(80.0f, 6.0f, 6.0f, 1.0f);
    private Color emissionGreen = new Color(13.0f, 118.0f, 21.0f, 1.0f);

    public Material schermo;
    public Image warningIcon;
    public Image lockedIcon;
    public Image unlockedIcon;

    private bool lightTimerOn = false; 

    private Collider _externCollider;

    public LightOut contatore; 

    private bool temperatura_corretta = false; 

    public void aumenta()
    {
        if( temperatura < TEMP_MAX && unlocked )
        {
            temperatura++;
        }

        temperatura_corretta = tempInRange();
        FindObjectOfType<AudioManager>().Play("BipCard");
    }

    public void diminuisci()
    {
        if( temperatura > TEMP_MIN && unlocked )
        {
            temperatura--;
        }

        temperatura_corretta = tempInRange();

        FindObjectOfType<AudioManager>().Play("BipCard");
    }

    public void unlockTerm()
    {
        lockedIcon.enabled = false;
        unlockedIcon.enabled = true;
        unlocked = true; 
    }

    public void lockTerm()
    {
        lockedIcon.enabled = true;
        unlockedIcon.enabled = false;
        unlocked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _externCollider = GetComponent<Collider>(); 
        temperatura = 19;
        orario = System.DateTime.Now; 

        schermo.SetColor("_Color", Color.red);
        //schermo.SetColor("_EmissionColor", emissionRed * 0.4f);

        TMPro.TextMeshProUGUI[] textMeshes = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        for (int i = 0; i < textMeshes.Length; i++)
        {
            TMPro.TextMeshProUGUI m = textMeshes[i];
            if( m.gameObject.name == "Orario_text" )
            {
                _orarioMesh = m; 
                _orarioMesh.text = string.Format("{0:00}:{1:00}:{2:00}", orario.Hour, orario.Minute, orario.Second);
            }
            else if( m.gameObject.name == "Temperatura_text")
            {
                _temperaturaMesh = m;
                _temperaturaMesh.text = temperatura.ToString(); 
            }
            else if( m.gameObject.name == "Data_text")
            {
                _dataMesh = m;
                _dataMesh.text = string.Format("{0:00}.{1:00}.{2:00}", orario.Day, orario.Month, orario.Year);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        orario = System.DateTime.Now;

        // Display Orario
        _orarioMesh.text = string.Format("{0:00}:{1:00}:{2:00}", orario.Hour, orario.Minute, orario.Second);

        // Display Temperatura
        _temperaturaMesh.text = temperatura.ToString();
        if ( temperatura_corretta ) // temperatura ottimale - schermo di colore verde 
        {
            // Display di colore verde
            schermo.SetColor("_Color", Color.green);
            //schermo.SetColor("_EmissionColor", emissionGreen * 0.4f );
            warningIcon.enabled = false;
            if( !lightTimerOn)
            {
                contatore.timerOn();
                lightTimerOn = true;
            }
        }
        else // temperatura troppo bassa o troppo alta - schermo di colore rosso + beep di allarme 
        {
            // Display di colore rosso
            schermo.SetColor("_Color", Color.red);
            //schermo.SetColor("_EmissionColor", emissionRed * 0.4f );
            warningIcon.enabled = true;

        }
    }

    private bool tempInRange()
    {
        return temperatura > 23 && temperatura < 28; 
    }

    public override void Interact(GameObject caller)
    {
        Grabbable grabbedObject = interactionManager.grabbedObject();
        if( grabbedObject == null)
        {
            return; 
        }
        else if ( grabbedObject.gameObject.name == "Tessera")
        {
            _externCollider.enabled = false;
            unlockTerm(); 
        }
        return; 
    }
}
