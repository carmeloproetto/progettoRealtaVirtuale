using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MedicoAnimationManager : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public GameObject destination;
    public GameObject destination2;

    private Animator _animator;

    private PrimoDialogoScript script_medico;

    //script per sblocco porta
    public GameObject door;
    private PortaInteractable script_door;

    public GameObject doorMain;
    private PortaInteractable script_doorMain;

    bool firstDestination;
    bool secondDestination;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        script_medico = GetComponent<PrimoDialogoScript>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        script_door = door.GetComponent<PortaInteractable>();
        script_doorMain = doorMain.GetComponent<PortaInteractable>();
        firstDestination = false;
        secondDestination = false;
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
        
      
        
        if(!FindObjectOfType<AudioMedicoManager>().isPlaying() && script_medico.walking == true){
            _animator.SetBool("Walking", true);
            navMeshAgent.SetDestination(destination.transform.position);
            firstDestination = true;
        }


        if (!navMeshAgent.pathPending && firstDestination == true)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude <= 0f)
                {
                    Debug.Log("Sono arrivato");

                    _animator.SetBool("Walking", false);
                    script_medico.walking = false;
                    firstDestination = false;
                    //firstDestination = true;
                }
        }

   
        if(script_door.doorLockedInTheMedicalCenter == false && script_doorMain.isTotalOpen == true){
            _animator.SetBool("Walking", true);
            navMeshAgent.SetDestination(destination2.transform.position);
            secondDestination = true;
        }

                if(!navMeshAgent.pathPending && secondDestination == true){
             if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude <= 0f)
                {
                    Debug.Log("Sono arrivato alla seconda destinazione");

                    _animator.SetBool("Walking", false);
                    script_medico.walking = false;
                    secondDestination = false;
                }

        }

    }
}
