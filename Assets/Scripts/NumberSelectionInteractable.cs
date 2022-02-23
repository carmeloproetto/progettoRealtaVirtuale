using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberSelectionInteractable : Interactable
{
    string currentNumber;
    List<string> numberSequence;
    List<string> correctSequence;
    public GameObject showNumbers;

    //int levelSize;
    private ShowNumbers showNumbers_script;

    //int level;

    bool show;

    
    //booleano per indicare la fine della risonanza
    bool finished;

    public GameObject medico;
    public GameObject fpc;
    public Transform posMedico;
    public Transform posFpc;

    private CambiaCameraRisonanza ScriptCambiaCamera;
    public GameObject cameraRisonanza;

    public GameObject displayGioco;

    public GameObject uiInteraction;

    public bool checkSequence()
    {
        int levelSize = showNumbers_script.levelSize;
       

        for (int i = 0; i < levelSize; i++)
        {

            if (correctSequence[i] != showNumbers_script.numberSequence[i])
                return false;
        }

        return true;
    }

    public override void Interact(GameObject caller)
    {
        currentNumber = gameObject.name;

       
        FindObjectOfType<AudioManager>().StopPlaying("BipCard");
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");

        numberSequence = showNumbers_script.numberSequence;


        if (currentNumber == "OK")

            if (numberSequence.Count == showNumbers_script.levelSize)
            {
                if (checkSequence())
                {
                    FindObjectOfType<AudioManager>().Play("Correct");
                   
                    showNumbers_script.DisplayMessage("CORRECT!");
                  

                    if (showNumbers_script.level == 1)
                    {
                        FindObjectOfType<AudioMedicoManager>().Play("Due");

                        showNumbers_script.level = 2;
                        showNumbers_script.levelSize = 7;
                        correctSequence.Clear();

                        correctSequence.Add("8");
                        correctSequence.Add("6");
                        correctSequence.Add("3");
                        correctSequence.Add("1");
                        correctSequence.Add("4");
                        correctSequence.Add("2");
                        correctSequence.Add("7");
                        /*for (int i = 0; i <= showNumbers_script.levelSize; i++)
                            correctSequence.Add(i.ToString());*/
                    }
                    else if (showNumbers_script.level == 2)
                    {
                        FindObjectOfType<AudioMedicoManager>().Play("Tre");
                        showNumbers_script.level = 3;
                        showNumbers_script.levelSize = 9;
                        correctSequence.Clear();

                        correctSequence.Add("9");
                        correctSequence.Add("5");
                        correctSequence.Add("3");
                        correctSequence.Add("8");
                        correctSequence.Add("4");
                        correctSequence.Add("1");
                        correctSequence.Add("6");
                        correctSequence.Add("2");
                        correctSequence.Add("7");
                        //correctSequence.Add(7);

                        /*for (int i = 0; i <= showNumbers_script.levelSize; i++)
                            correctSequence.Add(i.ToString());*/
                    }
                    else if (showNumbers_script.level == 3)
                    {
                        FindObjectOfType<AudioManager>().StopPlaying("Risonanza");
                        FindObjectOfType<AudioMedicoManager>().Play("ComplimentiRisonanza");
                        

                        StartCoroutine(ExecuteAfterTime(5));
                    }
                   
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("WrongCode");
                    showNumbers_script.DisplayMessage("WRONG!");      
                }
                numberSequence.Clear();
            }


        if (currentNumber == "CANC")
            numberSequence.RemoveAt(numberSequence.Count - 1);
        else if (numberSequence.Count < showNumbers_script.levelSize && currentNumber != "OK")
            numberSequence.Add(currentNumber);

  
    }

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Risonanza");
        FindObjectOfType<AudioMedicoManager>().Play("Rilassati");

        showNumbers_script = showNumbers.GetComponent<ShowNumbers>();
        show = false;


        correctSequence = showNumbers_script.correctSequence;

        finished = false;
        ScriptCambiaCamera = cameraRisonanza.GetComponent<CambiaCameraRisonanza>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (!audioSource.isPlaying)

        numberSequence = showNumbers_script.numberSequence;
        if (Input.GetKeyDown(KeyCode.B))
        {
            show = !show;
            numberSequence.Clear();
         
            if (show)
            {
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
           
        }

        if (finished == true && FindObjectOfType<AudioMedicoManager>().inPlay == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            AudioListener.pause = false;
        }

    }


    IEnumerator ExecuteAfterTime(float time)
    {
         yield return new WaitForSeconds(time);
 
        // Code to execute after the delay
        finished = true;
    }

    public override string GetDescription()
    {
        uiInteraction.SetActive(true);
        return "PER SCEGLIERE IL NUMERO";
    }
}
