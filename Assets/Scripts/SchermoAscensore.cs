using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchermoAscensore : MonoBehaviour
{
    private float _timer = 0f;
    private bool _timerOn = false;
    private bool _bloccato = false; 
    private int _numPiano = 0;

    public Image arrow_up;
    public Image arrow_down;
    public TMPro.TextMeshProUGUI piano;

    private Color arrowOnColor = new Color32(255, 255, 255, 255);
    private Color arrowOffColor = new Color32(255, 255, 255, 100);

    public Material displayColor;
    private Color disCol = new Color32(255, 0, 0, 255);
    public TMPro.TextMeshProUGUI pianoBase;
    public GameObject upDisplay;
    public GameObject downDisplay;


    private float _interval = 2f; 


    // Start is called before the first frame update
    void Start()
    {
        displayColor.SetColor("_Color", disCol);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerOn && _numPiano < 7)
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval) // cambia numero piano 
            {
                _numPiano++;
                piano.text = _numPiano.ToString();
                _timer = 0;
                if( _numPiano == 4 && !_bloccato )
                {
                    Blocca(); 
                }
            }
        }
    }

    public void Salita()
    {
        arrow_up.color = arrowOnColor;
        arrow_down.color = arrowOffColor; 
        _timerOn = true;
    }

    public void Salita2(){
        piano.text = "4";
        _numPiano = 4;
        displayColor.SetColor("_Color", disCol);
        pianoBase.enabled = true;
        upDisplay.SetActive(true);
        downDisplay.SetActive(true);
        arrow_up.color = arrowOnColor;
        arrow_down.color = arrowOffColor; 
        _timerOn = true;
    }

    public void Blocca()
    {
        arrow_up.color = arrowOffColor;
        arrow_down.color = arrowOffColor;
        _timerOn = false;
        _bloccato = true; 
    }

}
