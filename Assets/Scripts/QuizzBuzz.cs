using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzBuzz : MonoBehaviour
{
    public int number;
    public string answerLabel = "Sample Answer";
    private bool answer;
    private QuizzManager quizzManager;
    public Material matGreen;
    public Material matRed;

    private void Start() {
        answer = false;
        GetComponent<LabeledButton>().SetText(number.ToString());
        quizzManager = GameObject.Find("QuizzManager").GetComponent<QuizzManager>();
        ChangeColor(answer);
    }

    public void SetAnswer()
    {
        answer = !answer;
        ChangeColor(answer);
        quizzManager.SetAnswer(answerLabel, answer);
    }

    void ChangeColor(bool answer)
    {
        if(answer == true)
            GetComponentInChildren<Renderer>().material = matGreen;
        else
            GetComponentInChildren<Renderer>().material = matRed;
    
        
    }
}
