using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNumbers : MonoBehaviour
{
    public List<string> numberSequence;
    public bool correct;
    public int levelSize;
    public int level;
    public List<string> correctSequence;

    TMPro.TextMeshProUGUI display;
    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
        numberSequence = new List<string>();
        correct = false;
        levelSize = 5;
        level = 1;

        correctSequence.Add("1");
        correctSequence.Add("5");
        correctSequence.Add("9");
        correctSequence.Add("7");
        correctSequence.Add("2");

        /*for (int i = 0; i <= levelSize; i++)
        {
            correctSequence.Add(i.ToString());
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        string concat = "";
        numberSequence.ForEach(x => { concat += x; });  //Debug.Log(c + "-" + x); c++; });
        if(numberSequence.Count != 0)
            display.SetText(concat);
    }

    public void DisplayMessage(string msg)
    {
        display.SetText(msg);
    }



}
