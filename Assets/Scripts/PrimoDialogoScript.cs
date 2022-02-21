using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Pipes;

public class PrimoDialogoScript : MonoBehaviour

     
{
    public NPC npc;
    public NPC secondQuestion;
    public NPC thirdQuestion;
    public NPC liftQuestion;
    public NPC postLiftQuestion;
    public bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    //indica la domanda alla quale siamo
    public int numberOfQuestion;
    //far partire l'audio della seconda domanda una sola volta
    bool firstSecondDialogue;
    bool firstThirdDialogue;
    bool finsihedDialogue;

    private VHS.FirstPersonController fpc_script;

    private Animator _animator; 


    //script per sblocco porta
    public GameObject door;
    private PortaInteractable script_door;

    public bool walking;

    //script per sblocco ascensore
    public GameObject liftDoors;
    private OpenDoors script_liftDoors;

    //script per sblocco porta risonanza
    public GameObject risonanzaDoor;
    private PortaInteractable script_risonanzaDoor;

    // Start is called before the first frame update
    void Start()
    {
 
        dialogueUI.SetActive(false);
        fpc_script = player.GetComponent<VHS.FirstPersonController>();
        numberOfQuestion = 1;
        firstSecondDialogue = true;
        firstThirdDialogue = true;
        finsihedDialogue = false;
        _animator = GetComponent<Animator>(); 
        script_door = door.GetComponent<PortaInteractable>();
        walking = false;
        script_liftDoors = liftDoors.GetComponent<OpenDoors>();
        script_risonanzaDoor = risonanzaDoor.GetComponent<PortaInteractable>();
    }


    void OnMouseOver(){
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.5f){
            if(Input.GetAxis("Mouse ScrollWheel") < 0f){
                curResponseTracker++;
                if(numberOfQuestion == 1 || numberOfQuestion == 5 || numberOfQuestion == 8){
                    if(curResponseTracker >= npc.playerDialogue.Length - 1){
                        curResponseTracker = npc.playerDialogue.Length -1;
                    }
                }
                else if(numberOfQuestion == 2){
                    if(curResponseTracker >= secondQuestion.playerDialogue.Length - 1){
                        curResponseTracker = secondQuestion.playerDialogue.Length -1;
                    }
                }
                else if(numberOfQuestion == 3){
                    if(curResponseTracker >= thirdQuestion.playerDialogue.Length - 1){
                        curResponseTracker = thirdQuestion.playerDialogue.Length -1;
                    }
                }
            }
            else if(Input.GetAxis("Mouse ScrollWheel") > 0f){
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            

            //inizio il dialogo premendo e
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false){
                fpc_script.enabled = false;
                StartConversation();
            }
           /* else if(Input.GetKeyDown(KeyCode.E) && isTalking == true){
                fpc_script.enabled = true;
                EndDialogue();
            }*/

            if(numberOfQuestion == 1){
                if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0){
                    playerResponse.text = npc.playerDialogue[0];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) &&  FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("PrimoDialogoNo");
                        npcDialogueBox.text = npc.dialogue[1];
                        //passo alla seconda domanda
                        numberOfQuestion = 2;
                    }
                }
                else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1){
                    playerResponse.text = npc.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("PrimoDialogoSi");
                        npcDialogueBox.text = npc.dialogue[2];
                        //passo alla seconda domanda         
                        numberOfQuestion = 2;
                    }
                }
            }
            //secondo dialogo
            else if(numberOfQuestion == 2 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                if(firstSecondDialogue == true){
                    npcDialogueBox.text = secondQuestion.dialogue[0];
                    FindObjectOfType<AudioMedicoManager>().Play("SecondaDomandaMedico");
                    firstSecondDialogue = false;
                    curResponseTracker = 0;
                }

                if(curResponseTracker == 0 && secondQuestion.playerDialogue.Length >= 0){
                    playerResponse.text = secondQuestion.playerDialogue[0];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoSiForse");
                        npcDialogueBox.text = secondQuestion.dialogue[1];
                        numberOfQuestion = 3;
                    }
                }
                else if(curResponseTracker == 1 && secondQuestion.playerDialogue.Length >= 1){
                    playerResponse.text = secondQuestion.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoNo");
                        npcDialogueBox.text = secondQuestion.dialogue[2];
                        //passo alla quarta domanda (seguimi alla porta)         
                        numberOfQuestion = 4;
                    }
                }
                else if(curResponseTracker == 2 && secondQuestion.playerDialogue.Length >= 2){
                    playerResponse.text = secondQuestion.playerDialogue[2];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoSiForse");
                        npcDialogueBox.text = secondQuestion.dialogue[1];
                        //passo alla terza domanda         
                        numberOfQuestion = 3;
                    }
                }        
            }
            //terzo dialogo
            else if(numberOfQuestion == 3 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                if(firstThirdDialogue == true){
                    firstThirdDialogue = false;
                    curResponseTracker = 0;
                }

                if(curResponseTracker == 0 && thirdQuestion.playerDialogue.Length >= 0){
                    playerResponse.text = thirdQuestion.playerDialogue[0];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("TerzoDialogoSi");
                        npcDialogueBox.text = thirdQuestion.dialogue[0];
                        numberOfQuestion = 4;
                    }
                }
                else if(curResponseTracker == 1 && thirdQuestion.playerDialogue.Length >= 1){
                    playerResponse.text = thirdQuestion.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("TerzoDialogoNo");
                        npcDialogueBox.text = thirdQuestion.dialogue[1];
                        numberOfQuestion = 4;                
                    }
                }

            }
            else if(numberOfQuestion == 4 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                if(finsihedDialogue == false){
                    FindObjectOfType<AudioMedicoManager>().Play("FineConversazioneCentroMedico");
                    finsihedDialogue = true;
                    curResponseTracker = 0;
                    fpc_script.enabled = true;
                    dialogueUI.SetActive(false);
                    //script_door.doorLocked = false;
                    walking = true;
                    numberOfQuestion = 5; 
                }
            }
           //DIALOGO PRE ASCENSORE
           else if(numberOfQuestion == 5 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
            
               if(curResponseTracker == 0 && liftQuestion.playerDialogue.Length >= 0){
                    playerResponse.text = liftQuestion.playerDialogue[0];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) &&  FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("AscensoreSi");
                        npcDialogueBox.text = liftQuestion.dialogue[1];
                        numberOfQuestion = 6;
                    }
                }
                else if(curResponseTracker == 1 && liftQuestion.playerDialogue.Length >= 1){
                    playerResponse.text = liftQuestion.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("AscensoreNo");
                        npcDialogueBox.text = liftQuestion.dialogue[2];
                        
                        numberOfQuestion = 7;
                    }
                }   
           }
           //sblocca l'ascensore
            else if(numberOfQuestion == 6 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                dialogueUI.SetActive(false);
                fpc_script.enabled = true;
               // numberOfQuestion = 8;
                script_liftDoors.locked = false;
                Debug.Log("Ascensore sbloccato" + numberOfQuestion);
            }
            //si vuole uscire dalla simulazione
             else if(numberOfQuestion == 7 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                dialogueUI.SetActive(false);
                fpc_script.enabled = true;
               // numberOfQuestion = 8;
            }

            //DIALOGO POST ASCENSORE
           else if(numberOfQuestion == 8 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
            
               if(curResponseTracker == 0 && liftQuestion.playerDialogue.Length >= 0){
                    playerResponse.text = liftQuestion.playerDialogue[0];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) &&  FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("RisonanzaSi");
                        npcDialogueBox.text = postLiftQuestion.dialogue[0];
                        numberOfQuestion = 9;
                        script_risonanzaDoor.doorLocked = false;
                        Debug.Log("Ho detto si");
                    }
                }
                else if(curResponseTracker == 1 && liftQuestion.playerDialogue.Length >= 1){
                    playerResponse.text = liftQuestion.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("RisonanzaNo");
                        npcDialogueBox.text = liftQuestion.dialogue[2];
                        numberOfQuestion = 10;
                    }
                }   
           }
           //sblocca la porta della risonanza
            else if(numberOfQuestion == 9 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                dialogueUI.SetActive(false);
                fpc_script.enabled = true;
                //numberOfQuestion = 11;
                
                Debug.Log("Sblocco porta risonanza " + script_risonanzaDoor.doorLocked);
            }
            //si vuole uscire dalla simulazione
             else if(numberOfQuestion == 10 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                dialogueUI.SetActive(false);
                fpc_script.enabled = true;
                //numberOfQuestion = 11;
            }

        }
    }
    




    void StartConversation(){
        Debug.Log("Inizio Conversazione");
        //per domande negli ascensori
        if(numberOfQuestion == 5 || numberOfQuestion == 8){
           npcDialogueBox.text = liftQuestion.dialogue[0];
            FindObjectOfType<AudioMedicoManager>().Play("TeLaSentiDiProseguire");
        }
        else
            FindObjectOfType<AudioMedicoManager>().Play("IntroMedico");
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.dialogue[0];
    }

   /*void EndDialogue(){
       isTalking = false;
       dialogueUI.SetActive(false);
   }*/



}
