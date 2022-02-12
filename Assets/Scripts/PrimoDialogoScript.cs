using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Pipes;

public class PrimoDialogoScript : MonoBehaviour

     
{
    public NPC npc;
    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    //indica la domanda alla quale siamo
    int numberOfQuestion;
    //far partire l'audio della seconda domanda una sola volta
    bool firstSecondDialogue;
    bool firstThirdDialogue;
    bool finsihedDialogue;

    private VHS.FirstPersonController fpc_script;

    private Animator _animator; 



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
    }


    void OnMouseOver(){
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.5f){
            if(Input.GetAxis("Mouse ScrollWheel") < 0f){
                curResponseTracker++;
                if(curResponseTracker >= npc.playerDialogue.Length - 1){
                    curResponseTracker = npc.playerDialogue.Length -1;
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
                    npcDialogueBox.text = npc.dialogue[3];
                    FindObjectOfType<AudioMedicoManager>().Play("SecondaDomandaMedico");
                    firstSecondDialogue = false;
                    curResponseTracker = 0;
                }

                if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0){
                    playerResponse.text = npc.playerDialogue[0];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoNo");
                        npcDialogueBox.text = npc.dialogue[4];
                        numberOfQuestion = 4;
                    }
                }
                else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1){
                    playerResponse.text = npc.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoSiForse");
                        npcDialogueBox.text = npc.dialogue[5];
                        //passo alla terza domanda         
                        numberOfQuestion = 3;
                    }
                }
                else if(curResponseTracker == 2 && npc.playerDialogue.Length >= 2){
                    playerResponse.text = npc.playerDialogue[2];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoSiForse");
                        npcDialogueBox.text = npc.dialogue[5];
                        //passo alla terza domanda         
                        numberOfQuestion = 3;
                    }
                }        
            }
            else if(numberOfQuestion == 3 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                if(firstThirdDialogue == true){
                    //npcDialogueBox.text = npc.dialogue[3]; 
                    FindObjectOfType<AudioMedicoManager>().Play("SecondoDialogoSiForse");
                    firstThirdDialogue = false;
                    curResponseTracker = 0;
                }

                if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0){
                    playerResponse.text = npc.playerDialogue[3];
                    //se premo invio do conferma
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("TerzoDialogoSi");
                        npcDialogueBox.text = npc.dialogue[6];
                        numberOfQuestion = 4;
                    }
                }
                else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1){
                    playerResponse.text = npc.playerDialogue[0];
                    if(Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                        FindObjectOfType<AudioMedicoManager>().Play("TerzoDialogoNo");
                        npcDialogueBox.text = npc.dialogue[7];
                        numberOfQuestion = 4;
                        
                    }
                }

            }
            else if(numberOfQuestion == 4 && FindObjectOfType<AudioMedicoManager>().inPlay == false){
                if(finsihedDialogue == false){
                    //npcDialogueBox.text = npc.dialogue[3]; 
                    FindObjectOfType<AudioMedicoManager>().Play("FineConversazioneCentroMedico");
                    finsihedDialogue = true;
                    curResponseTracker = 0;
                    fpc_script.enabled = true;
                    dialogueUI.SetActive(false);
                }
            }

        }
    }
    




    void StartConversation(){
        Debug.Log("Inizio Conversazione");
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
