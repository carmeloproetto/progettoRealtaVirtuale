using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchermoContManager : MonoBehaviour
{
    private bool powerOn = true;
    public Material schermo;

    private TMPro.TextMeshProUGUI _contMesh;
    private TMPro.TextMeshProUGUI _superoMesh;

    public Image _warningImage;

    // Start is called before the first frame update
    void Start()
    {
        TMPro.TextMeshProUGUI[] textMeshes = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        for (int i = 0; i < textMeshes.Length; i++)
        {
            TMPro.TextMeshProUGUI m = textMeshes[i];
            if (m.gameObject.name == "cont_ext")
            {
                _contMesh = m;
            }
            else if (m.gameObject.name == "supero_ext")
            {
                _superoMesh = m;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!powerOn)
        {
            schermo.SetColor("_Color", Color.red);
            _superoMesh.enabled = true;
            _warningImage.enabled = true;
            _contMesh.enabled = false;
        }
        else
        {
            schermo.SetColor("_Color", Color.green);
            _superoMesh.enabled = false;
            _warningImage.enabled = false;
            _contMesh.enabled = true;
        }
    }

    public void powerOut()
    {
        powerOn = false;
    }

    public void On()
    {
        powerOn = true; 
    }
}

