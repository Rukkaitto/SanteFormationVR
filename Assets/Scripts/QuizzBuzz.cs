using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzBuzz : MonoBehaviour
{
    public string answerLabel = "Sample Answer";
    private bool answer = false;
    private QuizzManager quizzManager;
    public Material matGreen;
    public Material matRed;

    private void Start() {
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
        {
            GetComponent<TextMesh>().text = "V";
            GetComponentInChildren<Renderer>().material = matGreen;
        }
        else
        {
            GetComponent<TextMesh>().text = "F";
            GetComponentInChildren<Renderer>().material = matRed;
        }
        
    }
}
