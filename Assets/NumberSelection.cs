using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberSelection : MonoBehaviour
{

    string currentNumber;
    List<string> numberSequence;
    List<string> correctSequence;
    public GameObject showNumbers;
    public GameObject panel;

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

    public bool checkSequence()
    {
        int levelSize = showNumbers_script.levelSize;
        Debug.Log("checkSequence().levelSize = "+levelSize);

        //for (int i = 0; i < levelSize; i++)
        //{
        //    Debug.Log("Corretta: " + correctSequence[i] + " - Non corretta:" + numberSequence[i]);
        //}

        for (int i=0; i< levelSize; i++)
        {
            
            Debug.Log("Dentro il for");

           //Debug.Log("1Dentro il for - " + showNumbers_script.numberSequence[i]);
           Debug.Log("2Dentro il for - " + correctSequence.Count);

            if (correctSequence[i] != showNumbers_script.numberSequence[i])
               return false;
        }

        return true;
    }

    public void ButtonPressed()
    {
            
        currentNumber = gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text;
        FindObjectOfType<AudioManager>().StopPlaying("BipCard");
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");


        numberSequence = showNumbers_script.numberSequence;

        Debug.Log("current number : " + currentNumber);  

        if (currentNumber == "OK")
            
        if (numberSequence.Count == showNumbers_script.levelSize)
            {
                if (checkSequence())
                {
                    FindObjectOfType<AudioManager>().Play("Correct");
                    Debug.Log("Sequenza corretta!");
                    showNumbers_script.DisplayMessage("CORRECT!");
                    Debug.Log("Sequenza corretta! - Level:" + showNumbers_script.level);

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
                        FindObjectOfType<AudioMedicoManager>().Play("ComplimentiRisonanza");
                        finished = true;
                        FindObjectOfType<AudioManager>().StopPlaying("Risonanza");

                    }
                    Debug.Log("Sequenza corretta! - Level:" + showNumbers_script.level);
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("WrongCode");
                    showNumbers_script.DisplayMessage("WRONG!");
                    Debug.Log("Sequenza sbagliata!");
                }
                numberSequence.Clear();

                Debug.Log("dopo - level size: " + showNumbers_script.levelSize);
                Debug.Log("dopo - numberseq size: " + numberSequence.Count);
            }

        Debug.Log("3level size: " + showNumbers_script.levelSize);

        if (currentNumber == "CANC")
            numberSequence.RemoveAt(numberSequence.Count - 1);
        else if(numberSequence.Count < showNumbers_script.levelSize && currentNumber!="OK")
            numberSequence.Add(currentNumber);

        Debug.Log("2level size: " + showNumbers_script.levelSize);

    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Risonanza");
        FindObjectOfType<AudioMedicoManager>().Play("Rilassati");





        showNumbers_script = showNumbers.GetComponent<ShowNumbers>();
        show = false;

        

        correctSequence = showNumbers_script.correctSequence;

        Debug.Log(gameObject.name + "correctSeq size " + correctSequence.Count);

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
            Debug.Log("lista svuotata - size: " + numberSequence.Count);
            if (show)
            {
                Cursor.lockState = CursorLockMode.None;
                
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Debug.Log("prova");
        }

        if(finished == true && FindObjectOfType<AudioManager>().inPlay == false){
            fpc.transform.position = posFpc.transform.position;
            medico.transform.position = posMedico.transform.position;
            ScriptCambiaCamera.camRisonanzaOn = false;
            displayGioco.SetActive(false);

        }

    }
}
