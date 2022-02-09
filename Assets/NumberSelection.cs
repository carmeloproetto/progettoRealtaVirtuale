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


        
        numberSequence = showNumbers_script.numberSequence;

        Debug.Log("current number : " + currentNumber);

        if (currentNumber == "OK")
            if (numberSequence.Count == showNumbers_script.levelSize)
            {
                Debug.Log("dsdsadad");
                if (checkSequence())
                {
                    Debug.Log("Sequenza corretta!");
                    showNumbers_script.DisplayMessage("CORRECT!");
                    Debug.Log("Sequenza corretta! - Level:" + showNumbers_script.level);
                    if (showNumbers_script.level == 1)
                    {
                        showNumbers_script.level = 2;
                        showNumbers_script.levelSize = 7;
                        correctSequence.Clear();
                        for (int i = 1; i <= showNumbers_script.levelSize; i++)
                            correctSequence.Add(i.ToString());
                    }
                    else if (showNumbers_script.level == 2)
                    {
                        showNumbers_script.level = 3;
                        showNumbers_script.levelSize = 10;
                        correctSequence.Clear();
                        for (int i = 1; i <= showNumbers_script.levelSize; i++)
                            correctSequence.Add(i.ToString());
                    }
                    Debug.Log("Sequenza corretta! - Level:" + showNumbers_script.level);
                }
                else
                {
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
        showNumbers_script = showNumbers.GetComponent<ShowNumbers>();
        show = false;
        
        
        ShowPanel(false);

        correctSequence = showNumbers_script.correctSequence;

        Debug.Log(gameObject.name + "correctSeq size " + correctSequence.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            show = !show;
            numberSequence.Clear();
            Debug.Log("lista svuotata - size: " + numberSequence.Count);
            if (show)
            {
                ShowPanel(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                ShowPanel(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            Debug.Log("prova");
        }
    }

    void ShowPanel(bool x)
    {
        //panel.SetActive(x);
    }
}
