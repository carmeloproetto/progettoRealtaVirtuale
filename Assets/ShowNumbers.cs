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

        
        for (int i = 0; i <= levelSize; i++)
        {
            correctSequence.Add(i.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        int c = 0;
        string concat = "";
        numberSequence.ForEach(x => { concat += x; });  //Debug.Log(c + "-" + x); c++; });
        if(numberSequence.Count != 0)
            display.SetText(concat);
        c = 0;
    }

    public void DisplayMessage(string msg)
    {
        display.SetText(msg);
    }


}
