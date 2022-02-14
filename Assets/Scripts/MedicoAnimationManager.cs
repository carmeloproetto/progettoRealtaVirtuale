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

    public GameObject medico;
    private PrimoDialogoScript script_medico;

    //script per sblocco porta
    public GameObject door;
    private PortaInteractable script_door;

    public GameObject doorMain;
    private PortaInteractable script_doorMain;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        script_medico = medico.GetComponent<PrimoDialogoScript>();
        navMeshAgent = GetComponent<NavMeshAgent>();
         script_door = door.GetComponent<PortaInteractable>();
         script_doorMain = doorMain.GetComponent<PortaInteractable>();
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
        
        if(script_medico.walking == true && !FindObjectOfType<AudioMedicoManager>().isPlaying()){
            _animator.SetBool("Walking", true);
            navMeshAgent.SetDestination(destination.transform.position);
        }
        else{
            _animator.SetBool("Walking", false);
        }

        if(!navMeshAgent.pathPending)
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                if(!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude <= 0f){
                     Debug.Log("Sono arrivato");
                    //script_door.doorLockedInTheMedicalCenter = false;
                    _animator.SetBool("Walking", false); 
                }

        if(script_door.doorLockedInTheMedicalCenter == false && script_doorMain.isTotalOpen == true){
            Debug.Log("Gioco iniziato");
            navMeshAgent.SetDestination(destination2.transform.position);
        }
    }
}
