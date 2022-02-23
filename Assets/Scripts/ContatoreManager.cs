using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContatoreManager : MonoBehaviour
{
    private LevettaInteractable[] levette;
    private SchermoContManager schermoManager; 
    public Light luceSoffitto;
    public Light luceEmergenza;
    public GameObject luceEmergenzaMesh;
    public FPSInteractionManager interactionManager; 
    [SerializeField] private PrimoDialogoScript scriptDialogo; 

    [SerializeField] private PortaInteractable porta;
    
    public bool completedRoom;

    public GameObject uiInteraction; 

    bool aux;
    // Start is called before the first frame update
    void Start()
    {
        levette = GetComponentsInChildren<LevettaInteractable>();
        schermoManager = GetComponentInChildren<SchermoContManager>();
        completedRoom = false;
        aux = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( !levette[0].isUp() && levette[1].isUp() && levette[2].isUp() && !levette[3].isUp() && aux == true)
        {
            interactionManager.setDuringTask(false);
            uiInteraction.SetActive(true); 

            //Material materiale = luceSoffittoMesh.GetComponent<Renderer>().material; 
            //materiale.EnableKeyword("_EMISSION");
            //materiale.globalIlluminationFlags = MaterialGlobalIlluminationFlags.BakedEmissive;
            //materiale.SetColor("_EmissionColor", Color.white);

            luceEmergenza.enabled = false;
            luceEmergenzaMesh.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            luceEmergenzaMesh.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);

            RenderSettings.ambientLight = new Color32(235, 235, 235, 0);
            schermoManager.On();
            completedRoom = true;
            porta.Unlock();
            scriptDialogo.isTalking = false; 
            aux = false;

            foreach( LevettaInteractable levetta in levette)
            {
                levetta.GetComponent<Collider>().enabled = false; 
            }
        }
    }
}
