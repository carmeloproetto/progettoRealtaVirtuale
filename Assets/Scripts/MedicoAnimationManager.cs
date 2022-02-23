using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MedicoAnimationManager : Interactable
{

    private NavMeshAgent navMeshAgent;

    public GameObject destination;
    public GameObject destination2;

    private Animator _animator;

    private PrimoDialogoScript script_medico;

    //script per sblocco porta centro medico
    public GameObject door;
    private PortaInteractable script_doorCM;

    public GameObject doorMain;
    private PortaInteractable script_doorMainCM;

    //porta cabina
    public GameObject doorCabina;
    public GameObject doorCabinaMain;
    private PortaInteractable script_doorCabina;
    private PortaInteractable script_doorCabinaMain;


    public GameObject uiInteraction;



    bool firstDestination;
    bool secondDestination;
    bool firstWalkCompleted = false;
    bool secondWalkCompleted = false; 

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        script_medico = GetComponent<PrimoDialogoScript>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        script_doorCM = door.GetComponent<PortaInteractable>();
        script_doorMainCM = doorMain.GetComponent<PortaInteractable>();
        firstDestination = false;
        secondDestination = false;
        script_doorCabinaMain = doorCabinaMain.GetComponent<PortaInteractable>();
        script_doorCabina = doorCabina.GetComponent<PortaInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<AudioMedicoManager>().isPlaying()) // il medico sta parlando 
        {
            _animator.SetBool("Talking", true); 
        }
        else
        {
            _animator.SetBool("Talking", false); 
        }
        
      
        
        if(!FindObjectOfType<AudioMedicoManager>().isPlaying() && script_medico.walking == true && !firstWalkCompleted ){
            _animator.SetBool("Walking", true);
            navMeshAgent.SetDestination(destination.transform.position);
            firstDestination = true;
        }

        //verifioc l'arrivo alla prima destinazione
        if (!navMeshAgent.pathPending && firstDestination == true && !firstWalkCompleted)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude <= 0f)
                {
                    Debug.Log("Sono arrivato");
                    navMeshAgent.enabled = false;
                    script_doorCM.doorLocked = false;
                    _animator.SetBool("Walking", false);
                    script_medico.walking = false;
                    firstDestination = false;
                    firstWalkCompleted = true; 
                }
        }

   
        if(script_doorCM.doorLocked == false && script_doorMainCM.isTotalOpen == true && !secondWalkCompleted){
            //FindObjectOfType<AudioMedicoManager>().Play("InizioSimulazione");
            _animator.SetBool("Walking", true);
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(destination2.transform.position);
            secondDestination = true;
        }

        ////verifico l'arrivo alla seconda destinazione
        if(!navMeshAgent.pathPending && secondDestination == true && !secondWalkCompleted){
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude <= 0f)
                {
                    Debug.Log("Sono arrivato alla seconda destinazione");
                    _animator.SetBool("Walking", false);
                    navMeshAgent.enabled = false;
                    script_medico.walking = false;
                    secondDestination = false;
                    script_doorCM.doorLocked = true;
                    //sblocco la porta della cabina
                    script_doorCabina.doorLocked = false;
                    secondWalkCompleted = true; 
                }
        }

        

    }

    public override void Interact(GameObject caller)
    {
    
    }

    public override string GetDescription()
    {
        if(script_medico.isTalking == false){
            uiInteraction.SetActive(true);
            return "PER PARLARE CON IL MEDICO";
        } 
        else{
            uiInteraction.SetActive(false);
            return null;
        }
    }
}
